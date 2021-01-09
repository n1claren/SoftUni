using System;
using System.Collections.Generic;

namespace _02.A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            int inputCounter = 0;

            Dictionary<string, int> materials = new Dictionary<string, int>();

            List<int> values = new List<int>();
            List<string> keys = new List<string>();

            while ((input = Console.ReadLine()) != "stop")
            {
                inputCounter++;

                if (inputCounter % 2 != 0)
                {
                    keys.Add(input);
                }
                if (inputCounter % 2 == 0)
                {
                    values.Add(int.Parse(input));
                }
            }

            for (int i = 0; i < keys.Count; i++)
            {
                string key = keys[i];
                int value = values[i];

                if (materials.ContainsKey(key))
                {
                    materials[key] += value;
                }
                else
                {
                    materials.Add(key, value);
                }
            }

            foreach (var item in materials)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
