using System;
using System.IO;
using System.Collections.Generic;

namespace MergeFiles
{
    class MergeFiles
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            using (StreamReader reader = new StreamReader("../../../FileOne.txt"))
            {
                string input = reader.ReadLine();
                while (input != null)
                {
                    int num = int.Parse(input);

                    nums.Add(num);

                    input = reader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader("../../../FileTwo.txt"))
            {
                string input = reader.ReadLine();
                while (input != null)
                {
                    int num = int.Parse(input);

                    nums.Add(num);

                    input = reader.ReadLine();
                }
            }

            nums.Sort();

            using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
            {
                foreach (var num in nums)
                {
                    writer.WriteLine(num);
                }
            }
        }
    }
}
