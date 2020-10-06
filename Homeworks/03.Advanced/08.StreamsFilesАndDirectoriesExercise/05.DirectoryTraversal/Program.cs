using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hello, please enter a path: ");
            var path = Console.ReadLine(); //Do not enter a path to an open VS's solution !

            Dictionary<string, Dictionary<string, double>> filesInfo = new Dictionary<string, Dictionary<string, double>>();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] directoryFiles = directoryInfo.GetFiles();

            foreach (var file in directoryFiles)
            {
                if (!filesInfo.ContainsKey(file.Extension))
                {
                    filesInfo.Add(file.Extension, new Dictionary<string, double>());
                }

                filesInfo[file.Extension].Add(file.Name, file.Length / 1000.00);
            }

            var OrderedFilesInfo = filesInfo.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ThenByDescending(x => x.Value.Values)
                .ToDictionary(k => k.Key, v => v.Value);

            using (StreamWriter writer = new StreamWriter(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\DirectoryTraversal.txt"))
            {
                foreach (var file in OrderedFilesInfo)
                {
                    writer.WriteLine(file.Key);
                    foreach (var item in file.Value)
                    {
                        writer.WriteLine($"--{item.Key} - {item.Value}kb");
                    }
                }
            }
        }

    }
}
