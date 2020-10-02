using System;
using System.IO;

namespace _04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {

            using (StreamReader fileOneReader = new StreamReader("../../../FileOne.txt"))
            {
                using (StreamReader fileTwoReader = new StreamReader("../../../FileTwo.txt"))
                {
                    using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
                    {
                        string fileOneLine = fileOneReader.ReadLine();
                        string fileTwoLine = fileTwoReader.ReadLine();

                        while (fileOneLine != null && fileTwoLine != null)
                        {
                            writer.WriteLine(fileOneLine);
                            writer.WriteLine(fileTwoLine);

                            fileOneLine = fileOneReader.ReadLine();
                            fileTwoLine = fileTwoReader.ReadLine();
                        }

                    }
                }
            }
        }
    }
}
