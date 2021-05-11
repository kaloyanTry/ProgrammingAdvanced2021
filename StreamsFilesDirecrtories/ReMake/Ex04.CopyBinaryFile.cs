using System;
using System.IO;

namespace Ex04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream readStream = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (FileStream writeStream = new FileStream("../../../copiedImage.png", FileMode.Create))
                {
                    while (true)
                    {
                        byte[] bytesBuffer = new byte[4096];
                        int readBuffer = readStream.Read(bytesBuffer, 0, bytesBuffer.Length);

                        if (readBuffer == 0)
                        {
                            break;
                        }

                        writeStream.Write(bytesBuffer, 0, readBuffer);
                    }
                }
            }
        }
    }
}
