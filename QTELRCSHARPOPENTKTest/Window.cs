using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

//OpenTK
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenHolo
{
    public partial class Window : Form
    {
        // Variable and Object Declarations

        // Skips number of pixels to increase performance
        private int skipPixels = 5;

        // Color Mode: 0 = RGB, 1 = All White, 2 = HeatMap
        private byte colorMode = 0;

        // Controls resolution
        private int frameWidth = Semaphore.frameWidth, frameHeight = Semaphore.frameHeight;

        // Jaejin's
        // Variables for controlling camera view
        private Matrix4 lookat;
        private Matrix4d perspective;

        // Variables for controlling the POV/Camera using Mouse
        private int _mouseStartX = 0;
        private int _mouseStartY = 0;
        private float angleX = 0;
        private float angleY = 0;
        private float panX1 = 0;
        private float panY1 = 0;
        
        //Testing purposes for streaming Kinect directly
        private short[,,] pcdCollection;

        // Constructor and Initializer; Creates the form/window
        public Window()
        {
            InitializeComponent();
            //SphereCoordinates.setCoordinates(284, 0, -2987);
            //SphereCoordinates.setRadius(3000);
            if (frameWidth % skipPixels != 0 || frameHeight % skipPixels != 0)
            {
                Console.WriteLine("Application terminating. skipPixels Invalid.");
                Environment.Exit(0);
            }
        }

        #region Application Termination procedures
        // Properly exit application with escape so that Kinect resource can be released
        private void keyListener(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Console.WriteLine("Application terminating");
                Semaphore.signalKinectsToStop();
                //Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }

        // Properly exit application with close button so that Kinect resource can be released
        private void closeForm(object sender, FormClosingEventArgs e) 
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Console.WriteLine("Application terminating");
                Semaphore.signalKinectsToStop();
                //Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }
        #endregion

        #region GLControl. Mouse event handlers
        // Event Methods for Controlling Perspective on GUI with Mouse
        private void glControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                angleX += (e.X - _mouseStartX);
                angleY -= (e.Y - _mouseStartY);

                this.Cursor = Cursors.Cross;

                glControl1.Invalidate();
            }
            if (e.Button == MouseButtons.Left)
            {
                panX1 += (e.X - _mouseStartX);
                panY1 -= (e.Y - _mouseStartY);
                this.Cursor = Cursors.Hand;
                glControl1.Invalidate();
            }
            _mouseStartX = e.X;
            _mouseStartY = e.Y;
        }

        float zoomFactor;
        private void glControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                zoomFactor += 100f;
            else
                zoomFactor -= 100f;
            glControl1.Invalidate();
        }
        #endregion

        #region MenuStrip. ColorMode Selection Events
        private void rGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorMode = 0;
        }

        private void allWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorMode = 1;
        }

        private void heatMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorMode = 2;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            glControl1.Visible = false;
            // Displays the MessageBox.
            result = MessageBox.Show("Project Quick Telemetry Relay\nProject QTELR\nSpring2016@KSU\n" +
                "Developed by: Deion Anthony, Matthew Dylan Holt, Jaejin Hwang, \nMichael Milord, Houston Nguyen, and Begad Shaheen.",
                "About",
                buttons);
            glControl1.Visible = true;
        }

        private void highestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            skipPixels = 1;
        }
        private void medium4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            skipPixels = 4;
        }
        private void medium5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            skipPixels = 5;
        }
        private void low10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            skipPixels = 10;
        }
        #endregion

        // Function for loading the canvas/game window/3D view
        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.Black);
            SetupViewport();
            Semaphore.glControlLoaded = true;
            Semaphore.readyForPCD = true;
        }

        // Function determines what happens when the window is resized. 
        private void glControl1_Resize(object sender, EventArgs e)
        {
            // Recalculate positions of components in Form
        }

        private void mainWindow_Resize(object sender, EventArgs e)
        {
            //Console.WriteLine("Ding!");
        }

        // This function setups the parameters of the canvas/game window/3D view
        private void SetupViewport()
        {
            int w = glControl1.Width;
            int h = glControl1.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, w, 0, h, -1, 1); // Bottom-left corner pixel has coordinate (0, 0)
            GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
        }

        // This is the main function for determining what will be rendered
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //Basic Setup for viewing
            //Setup Perspective (lookat)
            //the first argument (Set of 3) is the location of your camera
            //the second argument (Set of 3) is the point the camera centers on
            //the third argument (Set of 3) is to indicate what direction should be considered "up"
            lookat = Matrix4.LookAt(0, 0, -1500 + zoomFactor, 0, 0, 0, 0, 1, 0);
            perspective = Matrix4d.CreatePerspectiveFieldOfView(1.04f, 16/9f, 1f, 100000f);

            //Setup camera
            GL.MatrixMode(MatrixMode.Projection);

            //Load Perspective
            GL.LoadIdentity();
            GL.LoadMatrix(ref perspective);

            //Load POV/Camera
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            //Apply transformations and rotations based on UI controls (Mouse)
            GL.Rotate(angleY, 1.0f, 0, 0);
            GL.Rotate(angleX, 0, 1.0f, 0);
            //GL.Translate(-panX1, 0, 0);
            //GL.Translate(0, panY1, 0);
            GL.Viewport((int)panX1, (int)panY1, glControl1.Width, glControl1.Height); // Use all of the glControl painting area

            //Size of window
            GL.Enable(EnableCap.DepthTest);

            //Enable correct Z Drawings
            GL.DepthFunc(DepthFunction.Less);

            GL.PushMatrix();

            // Objects to be displayed go here.
            // Y is up and down, Z is towards you, X is left and right 
            GL.Begin(PrimitiveType.Points);
            paintVertices();
            GL.End();
            GL.Begin(PrimitiveType.Lines);
            paintAxis();
            GL.End();
            GL.PopMatrix();

            glControl1.SwapBuffers();
        }

        #region Paint Methods. Used to update the Rendering

        //updateVertice Positions direct from Kinect Stream
        public void paintVertices()
        {
            if (Semaphore.glControlLoaded && Semaphore.pcdCollectionLoaded)
            {
                for(int row = 0; row < pcdCollection.GetLength(0); row+=skipPixels)
                {
                    for(int kinect = 0; kinect < pcdCollection.GetLength(2); kinect++)
                    {
                        if (colorMode == 0)
                        {
                            try
                            {
                                GL.Color3(System.Drawing.Color.FromArgb(
                                    pcdCollection[row, 3, kinect], 
                                    pcdCollection[row, 4, kinect], 
                                    pcdCollection[row, 5, kinect]));
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("RGB Data does not exist. Setting ColorMode to AllWhite.");
                                colorMode = 1;
                            }
                        }
                        else if (colorMode == 1)
                        {
                            GL.Color3(Color.White);
                        }
                        //else if (colorMode == 2)
                        //{
                        //    // Calculate distance between vertex and camera
                        //    double distance = (int)Math.Sqrt(Math.Pow(input[row, 0], 2) +
                        //        Math.Pow(input[row, 1], 2) +
                        //        Math.Pow(input[row, 2], 2));
                        //    // Scale 255 colour vaue with distance
                        //    int val = (int)((distance / 3800) * 255);
                        //    // If value is already 255 or more, just assign 255.
                        //    // If value is more than 255 and you pass it as a colour, APP will break.
                        //    if (val > 255)
                        //        val = 255;
                        //    GL.Color3(Color.FromArgb(255 - val, 0, val));
                        //}

                        // Assign X, Y, and Z to vertex from the split string and parsing to int
                        GL.Vertex3(pcdCollection[row, 0, kinect],
                            pcdCollection[row, 1, kinect],
                            pcdCollection[row, 2, kinect]);
                    }
                }
                    
            }
            glControl1.Invalidate();
        }

        // Paints an axis in the middle of canvas.
        private void paintAxis()
        {
            //Line X
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(100, 0, 0);

            //Line Y
            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 100, 0);

            //Line Z
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 100);

            glControl1.Invalidate();
        }
        #endregion

        public void inputPCDCollection(short[,,] input)
        {
            this.pcdCollection = input;
            //Console.WriteLine("PCD Loaded into MainWindow.");
            Semaphore.pcdCollectionLoaded = true;
        }
    }
}