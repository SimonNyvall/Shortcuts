using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace ShortActions
{
    public class Actons
    {
        public void doAction(string pathToAction)
        {
            string[] info = getInfo(pathToAction);

        }

        static string[] getInfo(string path)
        {
            string[] info = File.ReadAllLines(path);
            return info;
        }

        #region Actions

        static void createFolder(string path, string folderName)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine("Folder was created...");
            }
        }

        static void createFile(string path, string fileName)
        {
            if (!File.Exists(path))
            {

            }
        }

        static void writeToFile(string path, string content)
        {

        }

        static void compressfile(string path)
        {

        }

        static void moveFile(string currentPath, string disieredPath)
        {

        }

        static void renameFile(string path, string name)
        {

        }

        static void runScript(string path)
        {

        }

        #endregion Actions

    }
}