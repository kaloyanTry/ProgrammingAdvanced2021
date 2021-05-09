using System;
using System.Collections.Generic;
using System.IO;

namespace _04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numsList = new List<int>();

            using (StreamReader reader = new StreamReader("../../../FileOne.txt"))
            {
                string inputLine = reader.ReadLine();
                while (inputLine != null)
                {
                    int num = int.Parse(inputLine);
                    numsList.Add(num);

                    inputLine = reader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader("../../../FileTwo.txt"))
            {
                string inputLine = reader.ReadLine();
                while (inputLine != null)
                {
                    int num = int.Parse(inputLine);
                    numsList.Add(num);

                    inputLine = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
            {
                foreach (var num in numsList)
                {
                    writer.WriteLine(num);
                }
            }
        }
    }
}
