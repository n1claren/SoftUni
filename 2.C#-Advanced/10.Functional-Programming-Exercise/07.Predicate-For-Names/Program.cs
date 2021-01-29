using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetLenght = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split().ToList();

            Func<List<string>, List<string>> remover = new Func<List<string>, List<string>>(list =>
            {
                return list.Where(n => n.Length <= targetLenght).ToList();
            });

            Action<List<string>> print = new Action<List<string>>(list =>
            {
                Console.WriteLine(string.Join(Environment.NewLine, list));
            });

            names = remover(names);
            print(names);
        }
    }
}
