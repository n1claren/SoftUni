using System;
using System.Collections.Generic;

namespace _06.Equality_Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> peopleHash = new HashSet<Person>();
            SortedSet<Person> peopleSorted = new SortedSet<Person>();

            int people = int.Parse(Console.ReadLine());

            for (int i = 0; i < people; i++)
            {
                string[] personArg = Console.ReadLine().Split();

                string name = personArg[0];
                int age = int.Parse(personArg[1]);

                Person person = new Person(name, age);

                peopleHash.Add(person);
                peopleSorted.Add(person);
            }

            Console.WriteLine(peopleHash.Count);
            Console.WriteLine(peopleSorted.Count);
        }
    }
}
