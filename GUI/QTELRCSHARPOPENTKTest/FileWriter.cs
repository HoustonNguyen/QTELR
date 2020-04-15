using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
 * Used to write data to file
 */ 

namespace QTELR_Interface
{
    static class FileWriter
    {
        static string folderName = "DepthStreamDump";
        static string pathString = "C:\\";
        static int fileNum = 0;
        static string fileName = "DepthStreamData" + fileNum;

        static void createDirectory(string path)
        {
            System.IO.Directory.CreateDirectory(path);
        }


        public static void writeShort2TXT(short[] input)
        {
            fileName = "DepthStreamData" + fileNum + ".txt";
            string[] buffer = new string[input.Length];
            for (int i = 0; i < input.Length; i++ )
            {
                buffer[i] = input[i].ToString();
            }

            System.IO.File.WriteAllLines(@"C:\Test\" + fileName, buffer);
            fileNum++;
        }
        

    }
}
