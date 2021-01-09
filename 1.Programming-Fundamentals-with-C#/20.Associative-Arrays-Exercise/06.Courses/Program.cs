using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (input != "end")
            {
                string[] inputCollection = input.Split(" : ");

                if (courses.ContainsKey(inputCollection[0]))
                {
                    courses[inputCollection[0]].Add(inputCollection[1]);
                }
                else
                {
                    List<string> list = new List<string>();

                    list.Add(inputCollection[1]);

                    courses.Add(inputCollection[0], list);
                }

                input = Console.ReadLine();
            }

            foreach (var item in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");

                item.Value.Sort();

                for (int i = 0; i < item.Value.Count; i++)
                {
                    Console.WriteLine($"-- {item.Value[i]}");
                }
            }
        }
    }
}
