using System;
using System.Linq;

namespace _04.Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int firstElement = array[0];

                int[] temp = new int[array.Length];

                for (int j = 0; j < temp.Length - 1; j++)
                {
                    temp[j] = array[j + 1];
                }

                temp[temp.Length - 1] = firstElement;

                array = temp;
            }

            Console.WriteLine(string.Join(' ', array));
        }
    }
}
