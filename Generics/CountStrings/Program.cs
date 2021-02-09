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

            string value = Console.ReadLine();
            Box<string> comparableBox = new Box<string>(value);

            int count = GetGreaterCount(boxes, comparableBox);

            Console.WriteLine(count);
        }

        private static int GetGreaterCount<T>(List<Box<T>> boxes, Box<T> box) where T: IComparable
        {
            int count = 0;
            foreach (Box<T> item in boxes)
            {
                if (item.Value.CompareTo(box.Value) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        private static void SwapIndexes<T>(List<Box<T>> boxes, int firstIndex, int secondIndex) where T: IComparable
        {
            Box<T> tempValue = boxes[firstIndex];
            boxes[firstIndex] = boxes[secondIndex];
            boxes[secondIndex] = tempValue;        
        }
    }
}
