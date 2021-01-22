using System;
using System.Collections.Generic;

namespace _07.SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            HashSet<string> VIPguests = new HashSet<string>();

            string input = string.Empty;

            bool partyReceived = false;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "PARTY")
                {
                    partyReceived = true;
                    continue;
                }

                if (partyReceived)
                {
                    if (input[0] >= 0 && input[0] <= 9)
                    {
                        VIPguests.Remove(input);
                    }
                    else
                    {
                        guests.Remove(input);
                    }
                }
                else
                {
                    if (input[0] >= 0 && input[0] <= 9)
                    {
                        VIPguests.Add(input);
                    }
                    else
                    {
                        guests.Add(input);
                    }
                }
            }

            Console.WriteLine(guests.Count + VIPguests.Count);

            foreach (var guest in VIPguests)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}