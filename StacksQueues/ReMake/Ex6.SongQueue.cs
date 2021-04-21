using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex6.SongQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            Queue<string> queueSongs = new Queue<string>(input);

            while (queueSongs.Any())
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {
                    queueSongs.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    string[] addSongs = command.Split();

                    string songName = addSongs[1];
                    for (int i = 1; i < addSongs.Length - 1; i++)
                    {
                        songName += (" " + addSongs[i + 1]);
                    }

                    if (!queueSongs.Contains(songName))
                    {
                        queueSongs.Enqueue(songName);
                    }
                    else
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", queueSongs));
                }

                if (queueSongs.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                }
            }
        }
    }
}
