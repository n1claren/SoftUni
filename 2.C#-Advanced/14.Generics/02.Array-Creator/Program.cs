using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] array = ArrayCreator.Create(12, "Gogi");

            Console.WriteLine(string.Join(", ", array));
        }
    }
}
