using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> brackets = new Stack<char>();

            bool balanced = true;

            foreach (var character in input)
            {
                switch (character)
                {
                    case '(':
                        brackets.Push(character);
                        break;

                    case '[':
                        brackets.Push(character);
                        break;

                    case '{':
                        brackets.Push(character);
                        break;

                    case ')':
                        if (brackets.Count == 0 || brackets.Pop() != '(')
                        {
                            balanced = false;
                        }
                        break;

                    case ']':
                        if (brackets.Count == 0 || brackets.Pop() != '[')
                        {
                            balanced = false;
                        }
                        break;

                    case '}':
                        if (brackets.Count == 0 || brackets.Pop() != '{')
                        {
                            balanced = false;
                        }
                        break;
                }
            }

            if (balanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
