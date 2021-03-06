using System;

namespace _03.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();

            string[] urls = Console.ReadLine().Split();

            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        Smartphone smartphone = new Smartphone();
                        smartphone.Call(number);
                    }
                    else if (number.Length == 7)
                    {
                        StationaryPhone sp = new StationaryPhone();
                        sp.Call(number);
                    }
                    else
                    {
                        throw new InvalidNumberException();
                    }
                }
                catch (InvalidNumberException ine)
                {
                    Console.WriteLine(ine.Message);
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    Smartphone smartphone = new Smartphone();
                    smartphone.Browse(url);
                }
                catch (InvalidURLException iue)
                {
                    Console.WriteLine(iue.Message);
                }
            }
        }
    }
}
