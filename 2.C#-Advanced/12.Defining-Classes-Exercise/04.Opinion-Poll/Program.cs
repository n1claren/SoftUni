using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < inputs; i++)
            {
                string[] input = Console.ReadLine().Split();

                string currentName = input[0];
                int currentAge = int.Parse(input[1]);

                Person person = new Person(currentName, currentAge);

                people.Add(person);
            }

            List<Person> filteredPeople = people
                .Where(n => n.Age > 30)
                .OrderBy(n => n.Name)
                .ToList();

            foreach (var person in filteredPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
