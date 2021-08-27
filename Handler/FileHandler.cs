using System;
using System.Reflection;
using System.IO;

namespace AOC2015.Services
{
    internal class FileHandler
    {
        internal static string SanitizeClassToFilePath(string classname)
        {
            Assembly asm = Assembly.GetEntryAssembly();
            string basenamespace = asm.GetName().Name;

            classname = classname.Replace(basenamespace + ".", "");
            classname = classname.ToLower();
            return classname.Replace('.', '/');
        }

        internal static string ReadAllText(string filename)
        {
            filename = filename.Replace('/', Path.DirectorySeparatorChar);
            try {             
                try
                {
                    return File.ReadAllText(filename);
                }
                catch (DirectoryNotFoundException)
                {
                    createDirectoryForFile(filename);
                    throw new FileNotFoundException(Path.GetFullPath(filename));
                }
            }
            catch(FileNotFoundException e)
            {
                ConsoleColor originalConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine(e.Message);
                Console.ForegroundColor = originalConsoleColor;
                return "";
            }
        }

        private static void createDirectoryForFile(string filename)
        {
            string pathWithoutFile = filename.Substring(0, filename.LastIndexOf(Path.DirectorySeparatorChar));

            if(!Directory.Exists(pathWithoutFile))
            {
                Directory.CreateDirectory(pathWithoutFile);
            }
        }

        internal static void WriteText(string filename, string text)
        {
            filename = filename.Replace('/', Path.DirectorySeparatorChar);
            createDirectoryForFile(filename);

            using StreamWriter file = new(filename, append: false);
            file.Write(text);
        }
    }
}