using System;
using System.Numerics;
using pointmatcher.net;
//This class is responsible for ICP and concatenating PCDs

/* THIS IS A REFERENCE FOR HOW TO USE POINTMATCHER.NET
DataPoints reading = ...; // initialize your point cloud reading here
DataPoints reference = ...; // initialize your reference point cloud here
EuclideanTransform initialTransform = ...; // your initial guess at the transform from reading to reference
ICP icp = new ICP();
icp.ReadingDataPointsFilters = new RandomSamplingDataPointsFilter(prob: 0.1f);
icp.ReferenceDataPointsFilters = new SamplingSurfaceNormalDataPointsFilter(SamplingMethod.RandomSampling, ratio: 0.2f);
icp.OutlierFilter = new TrimmedDistOutlierFilter(ratio: 0.5f);
var transform = icp.Compute(reading, reference, initialTransform);
*/

//You change SOURCE and add it to REFERENCE.
//SOURCE is the one being transformed, translated, and rotated

namespace QTELR_Interface
{
    static class PointCloudManipulation
    {
        private static bool activeICP = false;
        private static bool referenceLoaded = false;
        private static int numOfConcatenations = 0;
        private static DataPoints source;
        private static DataPoints reference;
        private static ICP icp;


        public static void setup()
        {
            //I don't know what these are. Setting properties of ICP?
            icp = new ICP();
            icp.ReadingDataPointsFilters = new RandomSamplingDataPointsFilter(prob: 0.1f); 
            icp.ReferenceDataPointsFilters = new SamplingSurfaceNormalDataPointsFilter(SamplingMethod.Bin, ratio: 0.2f);
            icp.OutlierFilter = new TrimmedDistOutlierFilter(ratio: 0.5f);
            Console.WriteLine("ICP attributes set...");
        }

        //PerformICP on two pointclouds
        public static DataPoints performICP(DataPoints sourceInput, DataPoints referenceInput)
        {
            activeICP = true;
            Console.WriteLine("Performing ICP...");
            //Initialize the point cloud data that ICP will apply to
            // initialize your point cloud reading here
            // initialize your reference point cloud here
            //Console.WriteLine("DataPoints Source and Reference initialized...");

            EuclideanTransform initialTransform = new EuclideanTransform();
            //{translation = VectorHelpers.Mean(referenceInput.points), rotation = Quaternion.Identity}; // your initial guess at the transform from reading to reference
            //initialTransform.rotation = Quaternion.CreateFromYawPitchRoll(90f,0f,0f);
            //Compute the various transformations, translations, and rotations to one of the point clouds?
            EuclideanTransform transform = icp.Compute(sourceInput, referenceInput, initialTransform);
            //Console.WriteLine("Euclidean transformations computed...");

            //Do we still need to actually apply the transformations, translations, and rotations to PCD?
            //DataPoints bufferTransformedSource = new DataPoints();
            //bufferTransformedSource = ICP.ApplyTransformation(sourceInput, transform);
            //Console.WriteLine("Transformations applied to Source PCD...");

            //bufferTransformedSource = null;
            numOfConcatenations++;
            Console.WriteLine(numOfConcatenations + " operation(s) completed.");
            System.Media.SystemSounds.Beep.Play();
            activeICP = false;
            // Return concatenated result
            return join(sourceInput, referenceInput);
        }

        //Used to convert a short[,] array to a DataPoints object, which is what pointmatcher.net uses
        public static DataPoints short2DataPoints(short[,] input)
        {
            DataPoints result = new DataPoints();
            result.points = new DataPoint[input.GetLength(0)];
            for(int row = 0; row < input.GetLength(0); row ++)
            {
                Vector3 bufferPoint = new Vector3((float)input[row, 0], (float)input[row, 1], (float)input[row, 2]);
                DataPoint bufferDataPoint = new DataPoint();
                bufferDataPoint.normal = bufferPoint;
                bufferDataPoint.point = bufferPoint;
                result.points[row] = bufferDataPoint;
            }
            result.contiansNormals = true;
            return result;
        }

        //Used to convert  a DataPoints object to a short[,] array, which is what we use to display
        public static short[,] dataPoints2Short(DataPoints input)
        {
            short[,] result = new short[input.points.GetLength(0),3];
            for (int row = 0; row < input.points.GetLength(0); row++)
            {
                result[row, 0] = (short)input.points[row].point.X;
                result[row, 1] = (short)input.points[row].point.Y;
                result[row, 2] = (short)input.points[row].point.Z;
            }

            return result;
        }

        public static void inputShort(short[,] input)
        {
            if(!activeICP)
            {
                if (referenceLoaded)
                {
                    Console.WriteLine("Loading Source PCD...");
                    source = short2DataPoints(input);
                    reference = performICP(source, reference);
                    //Push single PCD to mainwindow for display
                    //Console.WriteLine("Pushing results to display...");
                }
                else
                {
                    Console.WriteLine("Loading Reference PCD...");
                    reference = short2DataPoints(input);
                    referenceLoaded = true;
                    
                }
                MyApplication.mainWindow.inputShort(dataPoints2Short(reference));
            }   
        }

        public static DataPoints join(DataPoints input1, DataPoints input2)
        {
            DataPoints result = new DataPoints();

            result.points = new DataPoint[input1.points.GetLength(0) + input2.points.GetLength(0)];
            int pointNumber = 0;
            for (int row = 0; row < input1.points.GetLength(0); row++)
            {
                result.points[pointNumber] = input1.points[row];
                pointNumber++;
            }
            for (int row = 0; row < input2.points.GetLength(0); row++)
            {
                result.points[pointNumber] = input2.points[row];
                pointNumber++;
            }

            //Console.WriteLine("Source and Reference concatenated...");
            return result;
        }

        public static void clearReference()
        {
            if (!activeICP)
            {
                numOfConcatenations = 0;
                reference = null;
                source = null;
                referenceLoaded = false;
                MyApplication.mainWindow.inputShort(new short[1,3]);
            }
        }
    }
}
