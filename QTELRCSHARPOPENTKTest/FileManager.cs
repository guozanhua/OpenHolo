using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
 * Used to write data to file
 * There are two pointclouds: Source and Compare. Source is the pointcloud that keeps getting updated by ICP.
 * It is also the pointcloud that is read by MainWindow.
 * There should only be two pointclouds at all times and they are in the form of TXTs
 */ 

namespace QTELR_Interface
{
    static class FileManager
    {
        //Used to guard against file writing if file writing is currently taking place.
        static bool isCurrentWriting = false;
        //static int fileNum = 0;
        static string folderName = @"DATADUMP";
        static string pathString;
        static string fileName;


        public static void createDirectory()
        {
            pathString = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(pathString))
                {
                    Console.WriteLine("The directory exists already.");
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(pathString);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(pathString));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public static void writeVertexData2TXT(short[,] input)
        {
            if(!isCurrentWriting)
            {
                isCurrentWriting = true;
                // Holds the data in string format
                string[] buffer = new string[input.GetLength(0)];
                if (sourceExist())
                {
                    // Sets the file name
                    fileName = "DepthStreamData" + 1 + ".txt";
                }
                else
                {
                    // Sets the file name
                    fileName = "DepthStreamData" + 0 + ".txt";
                }

                //Create file and write to it
                for (int row = 0; row < input.GetLength(0); row++)
                {
                    buffer[row] = input[row, 0].ToString() + " " + input[row, 1].ToString() + " " + input[row, 2].ToString() 
                        + " " + input[row, 3].ToString() + " " + input[row, 4].ToString() + " " + input[row, 5].ToString();
                }
                try
                {
                    File.WriteAllLines(pathString + "\\" + fileName, buffer);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Timing for Read/Write Off: {0}", e.ToString());
                }
                

                isCurrentWriting = false;
            } 
        }

        public static bool sourceExist()
        {
            if (File.Exists(pathString + "\\" + "DepthStreamData" + 0 + ".txt"))
            {
                return true;
            }
            else
                return false;
        }

        public static void deleteCompare()
        {
            if (File.Exists(pathString + "\\" + "DepthStreamData" + 1 + ".txt"))
            {
                File.Delete(pathString + "\\" + "DepthStreamData" + 1 + ".txt");
            }
        }

        public static void deleteSource()
        {
            if (File.Exists(pathString + "\\" + "DepthStreamData" + 0 + ".txt"))
            {
                File.Delete(pathString + "\\" + "DepthStreamData" + 0 + ".txt");
            }
        }

        public static string getSourcePath()
        {
            return pathString + "\\" + "DepthStreamData" + 0 + ".txt";
        }

        public static string getComparePath()
        {
            return pathString + "\\" + "DepthStreamData" + 1 + ".txt";
        }
    } 
}
