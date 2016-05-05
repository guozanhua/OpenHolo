using System;
using Microsoft.Kinect;
using System.Threading;

/*
 * This class manages the Kinect.
 * It provides all of the functions necessary to
 * use the Kinect and to get data from it.
 */

namespace QTELR_Interface
{
    class KinectManager
    {

        //Variable declarations
        private KinectSensor sensor;
        private Thread kinectManagementThread;

        // This holds color data
        private byte[] pixelColorData;

        ColorImageFormat COLOR_IMAGE_FORMAT = ColorImageFormat.RgbResolution640x480Fps30;
        DepthImageFormat DEPTH_IMAGE_FORMAT;

        int frameWidth = MyApplication.mainWindow.frameWidth;
        int frameHeight = MyApplication.mainWindow.frameHeight;

        // Constructor
        public KinectManager()
        {
            // Kinect manager has its own thread so that it can do stuff while
            // the app is listening for connections and doing form stuff
            kinectManagementThread = new Thread(startUp);
            kinectManagementThread.Start();
        }

        #region Kinect: StartUp and ShutDown Procedures
        // Initialization
        // Goes through the process of starting the Kinect
        private void startUp()
        {
            Console.WriteLine("Attempting to start Kinect...");
            getSensor();
            if(sensor != null)
            {
                prepareSensor();
                startSensor();
            }
            else
                // Something went wrong and the Kinect couldn't be started.
                Console.WriteLine("Kinect could not be started.");
        }

        // Instantiate sensor with device
        // Looks for the physical Kinect
        private void getSensor()
        {
            Console.WriteLine("Looking for Kinect...");
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.sensor = potentialSensor;
                    Console.WriteLine("Kinect Found and Connected.");
                    break;
                }
                else
                    Console.WriteLine("Kinect not found.");
            }
        }

        // This starts all of the streams
        // Right now, only the depth stream is started for testing.
        private void prepareSensor()
        {
            Console.WriteLine("Attempting Initializing Kinect sensors...");
            if (sensor != null)
            {

                //Detect Resolution and enables Depth Frame and Color Frame
                if (frameWidth == 640 && frameHeight == 480)
                {
                    DEPTH_IMAGE_FORMAT = DepthImageFormat.Resolution640x480Fps30;
                }
                else if (frameWidth == 320 && frameHeight == 240)
                {
                    DEPTH_IMAGE_FORMAT = DepthImageFormat.Resolution320x240Fps30;
                }
                else if (frameWidth == 80 && frameHeight == 60)
                {
                    DEPTH_IMAGE_FORMAT = DepthImageFormat.Resolution80x60Fps30;
                }
                else
                {
                    Console.WriteLine("Invalid Resolution. Shutting Down Application.");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
                // These are the various streams that are initialized on the Kinect.
                //sensor.ColorStream.Enable(ColorImageFormat.RawBayerResolution640x480Fps30); //This is a different color mode. Ignore.
                sensor.DepthStream.Enable(DEPTH_IMAGE_FORMAT);
                sensor.ColorStream.Enable(COLOR_IMAGE_FORMAT);
                sensor.SkeletonStream.Enable();
                // This is what would be used to draw colours from infrared (night vision mode).
                //sensor.ColorStream.Enable(ColorImageFormat.InfraredResolution640x480Fps30);
                
                // Register an event that fires when data is ready
                sensor.AllFramesReady += AllFramesReady;
                Console.WriteLine("Kinect Sensors Ready.");
            }
        }

        // Starts the device.
        private void startSensor()
        {
            Console.WriteLine("Starting Kinect...");
            if (this.sensor != null)
            {
                this.sensor.Start();
                Console.WriteLine("Kinect Started.");
            }
        }

        // Method to turn off Kinect or else it will keep streaming.
        public void stopKinect()
        {
            try
            {
                this.sensor.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
        #endregion

        //Event Kinect New Frame
        void AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            // Grab frames from stream 
            DepthImageFrame imageDepthFrame = e.OpenDepthImageFrame();
            ColorImageFrame imageColorFrame = e.OpenColorImageFrame();
            SkeletonFrame imageSkeletonFrame = e.OpenSkeletonFrame();

            if (imageDepthFrame != null && imageColorFrame != null && MyApplication.mainWindow.loaded)
            {
                CoordinateMapper mapper = new CoordinateMapper(sensor);
                SkeletonPoint[] skeletonPoints = new SkeletonPoint[imageDepthFrame.PixelDataLength];
                DepthImagePixel[] depthPixels = new DepthImagePixel[imageDepthFrame.PixelDataLength];

                // Copy the pixel data from the image to a temporary array
                imageDepthFrame.CopyDepthImagePixelDataTo(depthPixels);

                //Allocate array for color data
                pixelColorData = new byte[this.sensor.ColorStream.FramePixelDataLength];
                imageColorFrame.CopyPixelDataTo(pixelColorData);

                // Map Depth data to Skeleton points.
                // skeletonPoints is being changed as a result of this function call
                mapper.MapDepthFrameToSkeletonFrame(DEPTH_IMAGE_FORMAT, depthPixels, skeletonPoints);
                // Adjust coordinates of skeleton points according to the colour format
                // skeletonPoints is being changed as a result of this function call
                //mapper.MapColorFrameToSkeletonFrame(COLOR_IMAGE_FORMAT, DEPTH_IMAGE_FORMAT, depthPixels, skeletonPoints);

                // Convert SkeletonPoints data into short[][]
                // [x, y, z, Blue, Green, Red]
                short[,] vertexData = new short[(frameHeight * frameWidth), 6];
                int i = 0;
                for(int row = 0; row < frameHeight * frameWidth; row++)
                {
                    vertexData[row, 0] = (short)(skeletonPoints[row].X * 1000);//Store for X
                    vertexData[row, 1] = (short)(skeletonPoints[row].Y * 1000);//Store for Y
                    vertexData[row, 2] = (short)(skeletonPoints[row].Z * 1000);//Store for Z
                    //vertexData[row, 3] = (short)pixelColorData[i + 2];
                    //vertexData[row, 4] = (short)pixelColorData[i + 1];
                    //vertexData[row, 5] = (short)pixelColorData[i];
                    i += 4;
                }

                // Pass data to write to file
                //FileManager.writeVertexData2TXT(vertexData);
                if (MyApplication.mainWindow.signalToLoad)
                {
                    PointCloudManipulation.inputShort(vertexData);
                    MyApplication.mainWindow.signalToLoad = false;
                }
                
                //MyApplication.mainWindow.inputShort(vertexData);

                // Dispose frames for memory
                imageDepthFrame.Dispose();
                imageColorFrame.Dispose();
                imageSkeletonFrame.Dispose();
            }
        }
    }
}
