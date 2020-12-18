using System;

namespace ReadText
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                string text = Console.ReadLine();             
                if (text != "Stop")
                {
                Console.WriteLine(text);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
