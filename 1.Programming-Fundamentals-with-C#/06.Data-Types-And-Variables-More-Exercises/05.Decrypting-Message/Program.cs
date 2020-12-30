using System;
using System.Text;

namespace _05.Decrypting_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < lines; i++)
            {
                char input = char.Parse(Console.ReadLine());

                int temp = (int)input + key;

                char tempo = (char)temp;

                result.Append(tempo.ToString());
            }

            Console.WriteLine(result);
        }
    }
}
