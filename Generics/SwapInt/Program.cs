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
            List<Box<int>> boxes = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(input);

                boxes.Add(box);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SwapIndexes(boxes, indexes[0], indexes[1]);

            foreach (Box<int> currentBox in boxes)
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
