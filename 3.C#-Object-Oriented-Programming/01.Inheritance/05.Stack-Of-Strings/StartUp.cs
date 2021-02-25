using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackOfStrings = new StackOfStrings();

            Console.WriteLine(stackOfStrings.IsEmpty());

            List<string> strings = new List<string>()
            {
                "1",
                "2",
                "3",
                "4",
            };

            stackOfStrings.AddRange(strings);
        }
    }
}
