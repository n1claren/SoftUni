using System;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
     
            var input = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "END")
            {
                switch (input[0])
                {
                    case "Push":
                        var elements = input.Skip(1).Select(int.Parse);
                        stack.Push(elements);
                        break;

                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                        break;
                }

                input = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            PrintStack(stack);
            PrintStack(stack);
        }

        private static void PrintStack(Stack<int> stack)
        {
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
