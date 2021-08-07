using System;

namespace _02.LinearDS
{
    class ImplementList
    {
        static void Main(string[] args)
        {
            TooCoolList<int> list = new TooCoolList<int>();

            for (int i = 0; i < 100; i++)
            {
                list.Add(i);

                Console.WriteLine($"Internal array count: {list.InternalTooCount}");
                Console.WriteLine($"List count: {list.Count}");

                Console.WriteLine();
            }
        }
    }
}
