using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var inputs = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < inputs; i++)
            {
                var inputData = Console.ReadLine().Split();
                var person = new Person(inputData[0],
                                        inputData[1],
                                        int.Parse(inputData[2]),
                                        decimal.Parse(inputData[3]));

                people.Add(person);
            }

            Team team = new Team("BrutalAnger");

            people.ForEach(p => team.AddPlayer(p));

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve  team has {team.ReserveTeam.Count} players.");
        }
    }
}
