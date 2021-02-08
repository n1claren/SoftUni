using System;

namespace tralala
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputs; i++)
            {
                var input = Console.ReadLine();

                Box<string> box = new Box<string>(input);

                Console.WriteLine(box.ToString());
            }
        }
    }
}
