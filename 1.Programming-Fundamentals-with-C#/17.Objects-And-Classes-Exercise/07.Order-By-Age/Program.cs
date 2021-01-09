using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Order_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<People> people = new List<People>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var personData = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                People person = new People();

                person.PersonName = personData[0];
                person.PersonID = personData[1];
                person.PersonAge = int.Parse(personData[2]);

                people.Add(person);
            }

            List<People> sortedPeople = people
                .OrderBy(x => x.PersonAge)
                .ToList();

            foreach (var person in sortedPeople)
            {
                Console.WriteLine($"{person.PersonName} with ID: {person.PersonID} is {person.PersonAge} years old.");
            }
        }
    }

    class People
    {
        public string PersonName { get; set; }
        public string PersonID { get; set; }
        public int PersonAge { get; set; }
    }
}
