using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleGenerics
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> boxes = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Box<string> box = new Box<string>(input);

                boxes.Add(box);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SwapIndexes(boxes, indexes[0], indexes[1]);

            foreach (Box<string> currentBox in boxes)
            {
                Console.WriteLine(currentBox);
            }
        }

        private static void SwapIndexes<T>(List<Box<T>> boxes, int firstIndex, int secondIndex)
        {
            Box<T> tempValue = boxes[firstIndex];
            boxes[firstIndex] = boxes[secondIndex];
            boxes[secondIndex] = tempValue;        
        }
    }
}
