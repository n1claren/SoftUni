using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split()
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] commands = command.Split();

                string commandType = commands[0];

                string[] predicateArguments = commands.Skip(1).ToArray();

                Predicate<string> predicate = GetPredicate(predicateArguments);

                if (commandType == "Remove")
                {
                    guests.RemoveAll(predicate);
                }
                else if (commandType == "Double")
                {
                    for (int i = 0; i < guests.Count; i++)
                    {
                        string currentGuest = guests[i];

                        if (predicate(currentGuest))
                        {
                            guests.Insert(i + 1, currentGuest);
                            i++;
                        }
                    }
                }
            }

            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
        }

        static Predicate<string> GetPredicate(string[] predicateArguments)
        {
            string predicateType = predicateArguments[0];
            string predicateArgument = predicateArguments[1];

            Predicate<string> predicate = null;

            if (predicateType == "StartsWith")
            {
                predicate = new Predicate<string>(name =>
                {
                    return name.StartsWith(predicateArgument);
                });
            }
            else if (predicateType == "EndsWith")
            {
                predicate = new Predicate<string>(name =>
                {
                    return name.EndsWith(predicateArgument);
                });
            }
            else if (predicateType == "Length")
            {
                predicate = new Predicate<string>(name =>
                {
                    return name.Length == int.Parse(predicateArgument);
                });
            }

            return predicate;
        }
    }
}
