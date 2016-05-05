using System;
using System.Numerics;

namespace OpenHolo
{
    static class PointCloudManipulation
    {
        private static short[, ,] pointCloudCollection;
        private static EuclideanTransform transformation1;


        public static void setup()
        {
            // Wait for Kinects to start
            while (!Semaphore.kinectStarted) { }

            // Instantiate PCD arrays. Size is based on whether color is on or not.
            if (Semaphore.colorOn)
            {
                pointCloudCollection = new short[Semaphore.frameWidth * Semaphore.frameHeight, 6, Semaphore.num_sensors];
            }
                
            else
            {
                pointCloudCollection = new short[Semaphore.frameWidth * Semaphore.frameHeight, 3, Semaphore.num_sensors];
            }

            // Initialize pointCloudCollection with zeroes to avoid null
            for (int x = 0; x < pointCloudCollection.GetLength(0); x++)
            {
                for (int y = 0; y < pointCloudCollection.GetLength(1); y++)
                {
                    for (int z = 0; z < pointCloudCollection.GetLength(2); z++)
                    {
                        pointCloudCollection[x, y, z] = 0;
                    }
                }
            }
            transformation1 = new EuclideanTransform();
            //transformation1.translation = new Vector3(0, 0, 0);
            transformation1.rotation = new Quaternion(0, 0, (float)(2 * Math.PI), 0);
        }

        public static void inputPCD(short[,] input, int index)
        {
            if (index == 1)
            {
                //Apply transformation
                for (int row = 0; row < input.GetLength(0); row++)
                {
                    Vector3 bufferVector = new Vector3(input[row, 0], input[row, 1], input[row, 2]);
                    bufferVector = transformation1.Apply(bufferVector);
                    input[row, 0] = (short)bufferVector.X; //X
                    input[row, 1] = (short)bufferVector.Y; //Y
                    input[row, 2] = (short)bufferVector.Z; //Z
                }

            }

            for(int row = 0; row < input.GetLength(0); row++)
            {
                pointCloudCollection[row, 0, index] = input[row, 0]; //X
                pointCloudCollection[row, 1, index] = input[row, 1]; //Y
                pointCloudCollection[row, 2, index] = input[row, 2]; //Z
                if (Semaphore.colorOn)
                {
                    pointCloudCollection[row, 3, index] = input[row, 3];
                    pointCloudCollection[row, 4, index] = input[row, 4];
                    pointCloudCollection[row, 5, index] = input[row, 5];
                }
            }
            if (Semaphore.glControlLoaded && Semaphore.readyForPCD)
            {
                Semaphore.passPCDCollectionToMainWindow(pointCloudCollection);
            }
        }
    }
}
