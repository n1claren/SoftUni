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
                var input = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>(input);

                Console.WriteLine(box.ToString());
            }
        }
    }
}