using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace AOC2015.Services
{
    class FileOutputService
    {
        private static string filePrefix = "output/";
        private static string fileSuffix = ".output";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classname">The fully qualified name of the class, e.g. AOC2015.Day1.Part1</param>
        /// <returns></returns>
        public static void WriteOutput(string classname, string text)
        {
            classname = FileHandler.SanitizeClassToFilePath(classname);

            string filename = filePrefix + classname + fileSuffix;
            FileHandler.WriteText(filename, text);
        }
    }
}
