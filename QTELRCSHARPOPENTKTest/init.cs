using System;
using System.Drawing;
using System.Windows.Forms;
using OpenHolo;

namespace OpenHolo
{
    class init
    {
        // Declared so that other classes can reference these objects
        public static KinectManager kinectManager;
        public static Window mainWindow;

        [STAThread]
        public static void Main()
        {
            //Instantiate objects
            mainWindow = new Window();
            kinectManager = new KinectManager();
            PointCloudManipulation.setup();
            Application.Run(mainWindow);
        }
    }
}