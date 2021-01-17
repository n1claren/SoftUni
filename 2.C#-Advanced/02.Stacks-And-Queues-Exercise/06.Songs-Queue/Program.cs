using System;
using System.Collections.Generic;

namespace _06.Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songsInput = Console.ReadLine().Split(", ");

            Queue<string> songs = new Queue<string>(songsInput);

            while (songs.Count > 0)
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {
                    songs.Dequeue();
                }

                if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }

                if (command.Contains("Add"))
                {
                    string song = command.Remove(0, 4);

                    if (songs.Contains(song))
                    {
                        Console.WriteLine(song + " is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
