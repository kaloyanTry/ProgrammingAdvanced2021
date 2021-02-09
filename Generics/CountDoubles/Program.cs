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
            List<Box<double>> boxes = new List<Box<double>>();

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                Box<double> box = new Box<double>(input);

                boxes.Add(box);
            }

            double value = double.Parse(Console.ReadLine());
            Box<double> comparableBox = new Box<double>(value);

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
