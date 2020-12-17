using System;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double N1 = double.Parse(Console.ReadLine());
            double N2 = double.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());

            double sum = N1 + N2;
            double sub = N1 - N2;
            double left = N1 % N2;
            double multi = N1 * N2;
            double divide = N1 / N2;

            switch (operation)
            {  
                case '+':
                    if (sum % 2 == 0)
                    {
                        Console.WriteLine($"{N1} {operation} {N2} = {sum} - even");
                    }
                    else if (sum % 2 != 0)
                    {
                        Console.WriteLine($"{N1} {operation} {N2} = {sum} - odd");
                    }
                    break;

                case '-':
                    if (sub % 2 == 0)
                    {
                        Console.WriteLine($"{N1} {operation} {N2} = {sub} - even");
                    }
                    else if (sub % 2 != 0)
                    {
                        Console.WriteLine($"{N1} {operation} {N2} = {sub} - odd");
                    }
                    break;

                case '*':
                    if (multi % 2 == 0)
                    {
                        Console.WriteLine($"{N1} {operation} {N2} = {multi} – even");
                    }
                    else if (multi % 2 != 0)
                    {
                        Console.WriteLine($"{N1} {operation} {N2} = {multi} - odd");
                    }
                    break;

                case '%':
                    if (N2 != 0)
                    {
                        Console.WriteLine($"{N1} % {N2} = {left}");
                    }
                    else
                    {
                        Console.WriteLine($"Cannot divide {N1} by zero");
                    }
                    break;

                case '/':
                    if (N2 != 0)
                    {
                        Console.WriteLine($"{N1} / {N2} = {divide:F2}");
                    }
                    else
                    {
                        Console.WriteLine($"Cannot divide {N1} by zero");
                    }
                    break;

            }
   
        }
    }
}
