using System;
using System.IO;

namespace SliceFile
{
    class SliceFile
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("../../../sliceMe.txt");

            int fileLenght = (int)Math.Ceiling((double)text.Length / 4);

            int charsWritten = 0;

            for (int i = 1; i <= 4; i++)
            {
                using (StreamWriter writer = new StreamWriter("../../../slice-" + i + ".txt"))
                {
                    writer.Write(text.ToCharArray(), charsWritten, fileLenght);
                    charsWritten += fileLenght - 1;
                }
            }
        }
    }
}
