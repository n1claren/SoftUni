using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Oldest_Family_Member
{


    class Program
    {
        static void Main()
        {
            int familyMembers = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < familyMembers; i++)
            {
                string[] memberInfo = Console.ReadLine().Split();

                family.AddMember(memberInfo);
            }

            Person oldestMember = family.GetOledestMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }

    class Family
    {
        public List<Person> FamilyMembers { get; set; } = new List<Person>();

        public void AddMember(string[] memberInfo)
        {
            Person newMember = new Person(memberInfo[0], int.Parse(memberInfo[1]));

            this.FamilyMembers.Add(newMember);
        }

        public Person GetOledestMember()
        {
            return FamilyMembers.OrderByDescending(x => x.Age).First();
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}