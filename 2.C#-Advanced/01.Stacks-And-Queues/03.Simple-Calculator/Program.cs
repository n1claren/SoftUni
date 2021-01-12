using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Stack<string> calculator = new Stack<string>(input.Reverse());

            while (calculator.Count > 1)
            {
                int firstNum = int.Parse(calculator.Pop());
                string sign = calculator.Pop();
                int secondNum = int.Parse(calculator.Pop());
                int thirdNum;

                if (sign == "+")
                {
                    thirdNum = firstNum + secondNum;
                    calculator.Push(thirdNum.ToString());
                }   
                else
                {
                    thirdNum = firstNum - secondNum;
                    calculator.Push(thirdNum.ToString());
                }
            }

            Console.WriteLine(calculator.Pop());
        }
    }
}
