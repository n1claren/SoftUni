using System;
using System.Linq;
using System.Text;

namespace _01.Listy_Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] creationData = Console.ReadLine().Split();

            ListyIterator<string> collection;

            if (creationData.Length > 1)
            {
                collection = new ListyIterator<string>(creationData.Skip(1));
            }
            else
            {
                collection = new ListyIterator<string>();
            }

            var builder = new StringBuilder();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                switch (input)
                {
                    case "HasNext":
                        builder.AppendLine(collection.HasNext().ToString());
                        break;

                    case "Move":
                        builder.AppendLine(collection.Move().ToString());
                        break;

                    case "Print":
                        builder.AppendLine(collection.Print());
                        break;

                    case "PrintAll":

                        foreach (var item in collection)
                        {
                            builder.Append($"{item} ");
                        }

                        builder.AppendLine();

                        break;
                }
            }

            Console.WriteLine(builder.ToString().Trim());
        }
    }
}
