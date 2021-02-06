using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < inputs; i++)
            {
                string[] input = Console.ReadLine().Split();

                string currentName = input[0];
                int currentAge = int.Parse(input[1]);

                Person familyMember = new Person(currentName, currentAge);

                family.AddMember(familyMember);
            }

            Person oldestPerson = family.GetOldestMember();

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
