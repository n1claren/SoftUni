using System;
using System.Linq;

namespace _04.Pizza_Calories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input = string.Empty;

                Pizza pizza = null;
                Dough dough = null;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] inputArgs = input.Split();

                    if (inputArgs[0] == "Pizza")
                    {
                        pizza = new Pizza(inputArgs[1]);
                    }

                    if (inputArgs[0] == "Dough")
                    {
                        dough = new Dough(inputArgs[1], inputArgs[2], double.Parse(inputArgs[3]));
                        pizza.Dough = dough;
                    }

                    if (inputArgs[0] == "Topping")
                    {
                        pizza.AddTopping(new Topping(inputArgs[1], double.Parse(inputArgs[2])));
                    }
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
