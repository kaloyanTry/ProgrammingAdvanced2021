
using System;
using System.Linq;
using System.Collections.Generic;

namespace SongsQueue
{
    class SongsQueue
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            Queue<string> songsQueue = new Queue<string>(input);

            while (songsQueue.Any())
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {
                    songsQueue.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    string[] addSongs = command.Split();
                    if (!songsQueue.Contains(addSongs[1]))
                    {
                        songsQueue.Enqueue(addSongs[1]);
                    }
                    else
                    {
                        Console.WriteLine($"{addSongs[1]} is already contained!");
                    }
                }
                else if (command == "Show")
                {
                    Console.Write(string.Join(", ", songsQueue));
                }

                if (songsQueue.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                }
            }

        }
    }
}
