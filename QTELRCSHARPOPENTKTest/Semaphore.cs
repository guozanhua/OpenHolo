using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHolo
{
    class Semaphore
    {
        public static bool glControlLoaded = false;
        public static bool readyForPCD = false;
        public static bool pcdCollectionLoaded = false;
        public static bool colorOn = false;
        public static bool kinectStarted = false;
        public static int frameWidth = 640;
        public static int frameHeight = 480;
        public static int num_sensors;

        // Send to PointCloudManipulation
        public static void passPCD(short[,] input, int index)
        {
            PointCloudManipulation.inputPCD(input, index);
            //Console.WriteLine("PCD loaded into PCM.");
        }

        // Send to MainWindow
        public static void passPCDCollectionToMainWindow(short[,,] input)
        {
            init.mainWindow.inputPCDCollection(input);
            //Console.WriteLine("PCDC loaded into Window.");
        }

        public static void signalKinectsToStop()
        {
            init.kinectManager.stopKinect();
        }
    }
}
