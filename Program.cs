﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace findfile
{
    class Program
    {
        /// <summary>
        /// 系統目錄
        /// </summary>
        public static string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        /// <summary>
        /// 文件目錄
        /// </summary>
        public static string baseFilePath
        {
            get
            {
                return appPath.Substring(6);
            }
        }
        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        public static void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }
        public static void ProcessFile(string path)
        {
            String[] f ={"1516_P1AR_30",
"1516_P1CR_12",
"1516_P1CR_30",
"1516_P3AR_34",
"1516_P4AR_24",
"1516_SC1B_17",
"1516_SC1C_27",
"1516_SC2A_27",
"1516_SG1C_09"};
            foreach (string s in f)
            {
                if (path.Contains(s))
                {
                    Console.WriteLine("Processed file '{0}'.", path);
                }    
            }
        }
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine(args[0]);
            }
            Console.WriteLine(baseFilePath);
             ProcessDirectory(baseFilePath);
            Console.Read();
        }
    }
}