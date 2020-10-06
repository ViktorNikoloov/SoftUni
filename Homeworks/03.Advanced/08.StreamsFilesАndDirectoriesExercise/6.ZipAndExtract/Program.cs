using System;
using System.IO;
using System.IO.Compression;

namespace _6.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter a filePath: ");
            string filePath = Console.ReadLine();
            string[] fileName = filePath.Split("\\");

            ZipFile.CreateFromDirectory(filePath, @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\{fileName[fileName.Length -1]}.zip");
            ZipFile.ExtractToDirectory(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\{fileName[fileName.Length - 1]}.zip",
                @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\{fileName[fileName.Length - 1]}");
        }
    }
}
