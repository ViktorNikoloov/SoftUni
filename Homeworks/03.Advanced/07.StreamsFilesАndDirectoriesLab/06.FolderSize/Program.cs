using System;
using System.IO;

namespace _06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Console.ReadLine();
            string[] files = Directory.GetFiles(directoryPath);
            decimal size = 0;
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo info = new FileInfo(files[i]);
                size += info.Length;
            }
            string strSize = $"{size / 1024 / 1024:f14}";

            File.WriteAllText("../../../Output.txt", strSize);

        }
    }
}
