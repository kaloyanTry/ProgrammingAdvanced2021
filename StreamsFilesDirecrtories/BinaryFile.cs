using System;
using System.IO;

namespace CopyBinaryFile
{
    class BinaryFile
    {
        static void Main(string[] args)
        {
            using (FileStream readStream = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (FileStream writeStream = new FileStream("../../../copiedImage.png", FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];
                        
                        int readBuffer = readStream.Read(buffer, 0, buffer.Length);

                        if (readBuffer == 0)
                        {
                            break;
                        }

                        writeStream.Write(buffer, 0, readBuffer);
                    }

                }
            }
        }
    }
}
