using System;

namespace _05.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                int digit = int.Parse(input[0].ToString());

                switch (digit)
                {
                    case 0:
                        Console.Write(" ");
                        break;
                    case 2:
                        if (input.Length == 1)
                        {
                            Console.Write("a");
                        }
                        else if (input.Length == 2)
                        {
                            Console.Write("b");
                        }
                        else if (input.Length == 3)
                        {
                            Console.Write("c");
                        }
                        break;
                    case 3:
                        if (input.Length == 1)
                        {
                            Console.Write("d");
                        }
                        else if (input.Length == 2)
                        {
                            Console.Write("e");
                        }
                        else if (input.Length == 3)
                        {
                            Console.Write("f");
                        }
                        break;
                    case 4:
                        if (input.Length == 1)
                        {
                            Console.Write("g");
                        }
                        else if (input.Length == 2)
                        {
                            Console.Write("h");
                        }
                        else if (input.Length == 3)
                        {
                            Console.Write("i");
                        }
                        break;
                    case 5:
                        if (input.Length == 1)
                        {
                            Console.Write("j");
                        }
                        else if (input.Length == 2)
                        {
                            Console.Write("k");
                        }
                        else if (input.Length == 3)
                        {
                            Console.Write("l");
                        }
                        break;
                    case 6:
                        if (input.Length == 1)
                        {
                            Console.Write("m");
                        }
                        else if (input.Length == 2)
                        {
                            Console.Write("n");
                        }
                        else if (input.Length == 3)
                        {
                            Console.Write("o");
                        }
                        break;
                    case 7:
                        if (input.Length == 1)
                        {
                            Console.Write("p");
                        }
                        else if (input.Length == 2)
                        {
                            Console.Write("q");
                        }
                        else if (input.Length == 3)
                        {
                            Console.Write("r");
                        }
                        else if (input.Length == 4)
                        {
                            Console.Write("s");
                        }
                        break;
                    case 8:
                        if (input.Length == 1)
                        {
                            Console.Write("t");
                        }
                        else if (input.Length == 2)
                        {
                            Console.Write("u");
                        }
                        else if (input.Length == 3)
                        {
                            Console.Write("v");
                        }
                        break;
                    case 9:
                        if (input.Length == 1)
                        {
                            Console.Write("w");
                        }
                        else if (input.Length == 2)
                        {
                            Console.Write("x");
                        }
                        else if (input.Length == 3)
                        {
                            Console.Write("y");
                        }
                        else if (input.Length == 4)
                        {
                            Console.Write("z");
                        }
                        break;
                }

            }
        }
    }
}
