using System;
using System.IO;

namespace _05.SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream stream = new FileStream("../../../sliceMe.txt", FileMode.Open))
            {
                long size = stream.Length / 4;
                
                for (int i = 0; i < 4; i++)
                {
                    using (FileStream pieceStream = new FileStream($"../../../part-{i+1}.txt",FileMode.Create))
                    {
                        byte[] buffer = new byte[size];
                        int count = 0;

                        while (count < size)
                        {
                            stream.Read(buffer, 0, buffer.Length);
                            pieceStream.Write(buffer, 0, buffer.Length);

                            count+= buffer.Length;

                        }
                    }
                }
            }
        }
    }
}
