using System;

namespace _01.Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            string data = Console.ReadLine();

            DataType(dataType, data);
        }

        static void DataType(string dataType, string data)
        {
            if (dataType == "int")
            {
                int intData = int.Parse(data);

                intData *= 2;

                Console.WriteLine(intData);
            }
            else if (dataType == "real")
            {
                double doubleData = double.Parse(data);

                doubleData *= 1.5;

                Console.WriteLine($"{doubleData:f2}");
            }
            else
            {
                Console.WriteLine($"${data}$");
            }
        }
    }
}
