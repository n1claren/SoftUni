using System;

namespace OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double oddmax = int.MinValue;
            double oddmin = int.MaxValue;

            double evenmax = int.MinValue;
            double evenmin = int.MaxValue;

            double evensum = 0;
            double oddsum = 0;


            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evensum += num;

                    if (num > evenmax)
                    {
                        evenmax = num;
                    }
                    
                    if (num < evenmin)
                    {
                        evenmin = num;
                    }
                }

                else if (i % 2 != 0)
                {
                    oddsum += num;

                    if (num > oddmax)
                    {
                        oddmax = num;
                    }

                    if (num < oddmin)
                    {
                        oddmin = num;
                    }
                }
            }

            if (n >= 2)
            {
            Console.WriteLine($"OddSum={oddsum:F2},");
            Console.WriteLine($"OddMin={oddmin:F2},");
            Console.WriteLine($"OddMax={oddmax:F2},");
            Console.WriteLine($"EvenSum={evensum:F2},");
            Console.WriteLine($"EvenMin={evenmin:F2},");
            Console.WriteLine($"EvenMax={evenmax:F2}");
            }
            
            else if (n == 0)
            {
                Console.WriteLine($"OddSum=0.00,");
                Console.WriteLine($"OddMin=No,");
                Console.WriteLine($"OddMax=No,");
                Console.WriteLine($"EvenSum=0.00,");
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
            }

            else if (n == 1)
            {
                Console.WriteLine($"OddSum={oddsum:F2},");
                Console.WriteLine($"OddMin={oddmin:F2},");
                Console.WriteLine($"OddMax={oddmax:F2},");
                Console.WriteLine($"EvenSum=0.00,");
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
            }
        }
    }
}
