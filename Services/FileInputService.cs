using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace AOC2015.Managers
{
    class FileInputService
    {
        private static string filePrefix = "input/";
        private static string fileSuffix = ".input";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classname">The fully qualified name of the class, e.g. AOC2015.Day1.Part1</param>
        /// <returns></returns>
        public static string ReadInput(string classname)
        {
            //each day has the same input
            int dayPosition = classname.IndexOf("Day");
            int length = classname.IndexOf(".", dayPosition) - dayPosition;
            string day = classname.Substring(dayPosition, length);
            classname = FileHandler.SanitizeClassToFilePath(day);

            string filename = filePrefix + classname + fileSuffix;
            return FileHandler.ReadAllText(filename);

        }
    }
}
