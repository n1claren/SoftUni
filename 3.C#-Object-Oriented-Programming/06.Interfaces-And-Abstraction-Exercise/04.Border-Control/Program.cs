using System;
using System.Collections.Generic;

namespace _04.Border_Control
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<IIdentifiable> IDs = new List<IIdentifiable>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] splittedInput = input.Split();

                if (splittedInput.Length == 2)
                {
                    Robot robot = new Robot(splittedInput[0], splittedInput[1]);
                    IDs.Add(robot);
                }
                else if (splittedInput.Length == 3)
                {
                    Human human = new Human(splittedInput[0], int.Parse(splittedInput[1]), splittedInput[2]);
                    IDs.Add(human);
                }
            }

            string fakeIDlastDigits = Console.ReadLine();

            foreach (var IIDF in IDs)
            {
                string currentID = IIDF.Id;

                if (currentID.EndsWith(fakeIDlastDigits))
                {
                    Console.WriteLine(currentID);
                }
            }
        }
    }
}
