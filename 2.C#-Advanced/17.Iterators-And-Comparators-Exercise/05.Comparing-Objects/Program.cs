using System;
using System.Collections.Generic;

namespace _05.Comparing_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] splittedInput = input.Split();

                string name = splittedInput[0];
                int age = int.Parse(splittedInput[1]);
                string town = splittedInput[2];

                Person person = new Person(name, age, town);

                people.Add(person);
            }

            int index = int.Parse(Console.ReadLine());

            Person comparable = people[index - 1];

            int equalPeople = 0;
            int unequalPeople = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(comparable) == 0)
                {
                    equalPeople++;
                }
                else
                {
                    unequalPeople++;
                }
            }

            if (equalPeople <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPeople} {unequalPeople} {people.Count}");
            }
        }
    }
}
