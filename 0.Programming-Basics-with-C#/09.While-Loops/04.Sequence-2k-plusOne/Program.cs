﻿using System;

namespace Sequence2k
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int num = 1;

            while (num <= n)
            {
                Console.WriteLine(num);
                num *= 2;
                num++;
            }
        }
    }
}
