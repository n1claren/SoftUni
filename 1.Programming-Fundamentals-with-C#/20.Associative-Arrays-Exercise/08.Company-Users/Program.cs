using System;
using System.Collections.Generic;

namespace _08.Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<string, List<string>> companies = new SortedDictionary<string, List<string>>();

            while (input?.ToLower() != "end")
            {
                string[] inputData = input.Split(" -> ");

                string company = inputData[0];
                string ID = inputData[1];

                if (companies.ContainsKey(company))
                {
                    if (companies[company].Contains(ID))
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        companies[company].Add(ID);
                    }
                }
                else
                {
                    List<string> IDs = new List<string>();

                    IDs.Add(ID);

                    companies.Add(company, IDs);
                }

                input = Console.ReadLine();
            }

            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);

                for (int i = 0; i < company.Value.Count; i++)
                {
                    Console.WriteLine($"-- {company.Value[i]}");
                }
            }
        }
    }
}
