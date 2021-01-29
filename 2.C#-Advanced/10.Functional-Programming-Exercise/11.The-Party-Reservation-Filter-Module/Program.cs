using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.The_Party_Reservation_Filter_Module
{

    public class Program
    {
        public static void Main()
        {
            List<string> guests = new List<string>(Console.ReadLine().Split());

            List<string> filters = new List<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Print")
            {

                string[] commands = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Add filter")
                {
                    filters.Add(commands[1] + " " + commands[2]);
                }
                else if (commands[0] == "Remove filter")
                {
                    filters.Remove(commands[1] + " " + commands[2]);
                }  
            }

            foreach (var filter in filters)
            {
                string[] commands = filter.Split();

                if (commands[0] == "Starts")
                {
                    guests = guests.Where(x => !x.StartsWith(commands[2])).ToList();
                }
                else if (commands[0] == "Ends")
                {
                    guests = guests.Where(x => !x.EndsWith(commands[2])).ToList();
                }
                else if (commands[0] == "Length")
                {
                    guests = guests.Where(x => x.Length != int.Parse(commands[1])).ToList();
                }
                else if (commands[0] == "Contains")
                {
                    guests = guests.Where(x => !x.Contains(commands[1])).ToList();
                }
            }

            if (guests.Any())
            {
                Console.WriteLine(string.Join(" ", guests));
            }
        }
    }
}