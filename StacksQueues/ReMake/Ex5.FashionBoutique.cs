using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex5.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stackClothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int capacityRack = int.Parse(Console.ReadLine());

            int countRacks = 1;
            int rack = 0;

            while (stackClothes.Any())
            {
                int pieceCloth = stackClothes.Pop();
                rack += pieceCloth;

                if (rack > capacityRack)
                {
                    countRacks++;
                    rack = pieceCloth;
                }
            }

            Console.WriteLine(countRacks);
        }
    }
}
