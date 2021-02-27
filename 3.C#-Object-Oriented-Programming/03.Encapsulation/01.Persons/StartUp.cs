using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < inputs; i++)
            {
                var inputData = Console.ReadLine().Split();

                var person = new Person(inputData[0], inputData[1], int.Parse(inputData[2]));

                people.Add(person);
            }

            people.OrderBy(p => p.FirstName)
                   .ThenBy(p => p.Age)
                   .ToList()
                   .ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
