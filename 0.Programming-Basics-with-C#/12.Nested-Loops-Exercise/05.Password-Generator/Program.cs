﻿using System;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (int k = 97; k < 97 + l; k++)
                    {
                        for (int t = 97; t < 97 + l; t++)
                        {
                            for (int m = 1; m <= n; m++)
                            {
                                if (m > i && m > j)
                                {
                                    Console.Write($"{i}{j}{Convert.ToChar(k)}{Convert.ToChar(t)}{m} ");
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}
