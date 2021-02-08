using System;

namespace _08.Threeuple
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] inputOne = Console.ReadLine().Split();

            var threeupleOne = new Threeuple<string, string, string>(
                $"{inputOne[0]} {inputOne[1]}",
                inputOne[2],
                inputOne[3]);

            string[] inputTwo = Console.ReadLine().Split();

            var threeupleTwo = new Threeuple<string, int, bool>(
                inputTwo[0],
                int.Parse(inputTwo[1]),
                inputTwo[2] == "drunk");

            string[] inputThree = Console.ReadLine().Split();

            var threeupleThree = new Threeuple<string, double, string>(
                inputThree[0],
                double.Parse(inputThree[1]),
                inputThree[2]);

            Console.WriteLine(threeupleOne.ToString());
            Console.WriteLine(threeupleTwo.ToString());
            Console.WriteLine(threeupleThree.ToString());
        }
    }
}
