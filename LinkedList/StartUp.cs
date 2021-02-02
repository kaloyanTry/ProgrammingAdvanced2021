using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);

            list.ForEach(Console.WriteLine);

            int[] arr = list.ToArray();

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
