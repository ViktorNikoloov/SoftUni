using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream CopyAFile = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (FileStream WriteAFile = new FileStream("../../../copyMe(1).png", FileMode.Create))
                {
                    byte[] buffer = new byte[1024];
                    int count = 0;
                    while (count < CopyAFile.Length)
                    {
                        CopyAFile.Read(buffer, 0, buffer.Length);
                        WriteAFile.Write(buffer, 0, buffer.Length);
                        count += buffer.Length;

                    }
                }
            }
        }
    }
}
