using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Shopping_Spree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            List<Product> products = new List<Product>();

            try
            {
                people = Console.ReadLine()
                            .Split(';', StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => s.Split('='))
                            .Select(s => new Person(s[0], decimal.Parse(s[1])))
                            .ToList();

                products = Console.ReadLine()
                          .Split(';', StringSplitOptions.RemoveEmptyEntries)
                          .Select(s => s.Split('='))
                          .Select(s => new Product(s[0], decimal.Parse(s[1])))
                          .ToList();

                string input = string.Empty;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    Person person = people.FirstOrDefault(p => p.Name == command[0]);
                    Product product = products.FirstOrDefault(p => p.Name == command[1]);

                    if (person != null && product != null)
                    {
                        person.ShopProduct(product);
                    }
                }

                foreach (Person person in people)
                {
                    Console.WriteLine(person);
                }

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
