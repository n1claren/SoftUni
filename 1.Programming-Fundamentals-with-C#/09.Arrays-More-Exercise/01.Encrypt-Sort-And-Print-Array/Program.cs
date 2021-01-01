using System;

namespace _01.Encrypt_Sort_And_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] inputArray = new string[n];

            for (int i = 0; i < n; i++)
            {
                inputArray[i] = Console.ReadLine();
            }

            int[] numbers = new int[n];

            for (int i = 0; i < inputArray.Length; i++)
            {
                int temp = 0;

                for (int z = 0; z < inputArray[i].Length; z++)
                {
                    int temp2 = 0;

                    if (inputArray[i][z].ToString() == "A" ||
                        inputArray[i][z].ToString() == "a" ||
                        inputArray[i][z].ToString() == "E" ||
                        inputArray[i][z].ToString() == "e" ||
                        inputArray[i][z].ToString() == "O" ||
                        inputArray[i][z].ToString() == "o" ||
                        inputArray[i][z].ToString() == "U" ||
                        inputArray[i][z].ToString() == "u" ||
                        inputArray[i][z].ToString() == "I" ||
                        inputArray[i][z].ToString() == "i")
                    {
                        temp2 = (int)inputArray[i][z] * inputArray[i].Length;
                    }
                    else
                    {
                        temp2 = (int)inputArray[i][z] / inputArray[i].Length;
                    }

                    temp += temp2;
                }

                numbers[i] = temp;
            }

            Array.Sort(numbers);

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
