using System;
using System.Collections.Generic;

namespace _05.Birthday_Celebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<IBirthable> birthdays = new List<IBirthable>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] splittedInput = input.Split();

                if (splittedInput[0] == "Citizen")
                {
                    Human human = new Human(
                        splittedInput[1], 
                        int.Parse(splittedInput[2]), 
                        splittedInput[3], 
                        splittedInput[4]);

                    birthdays.Add(human);
                }
                else if (splittedInput[0] == "Pet")
                {
                    Pet pet = new Pet(splittedInput[1], splittedInput[2]);
                    birthdays.Add(pet);
                }
            }

            string printYear = Console.ReadLine();

            foreach (var birthable in birthdays)
            {
                if (birthable.Birthdate.EndsWith(printYear))
                {
                    Console.WriteLine(birthable.Birthdate);
                }
            }
        }
    }
}
