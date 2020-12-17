using System;
using System.Transactions;

namespace YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
           double squareM = double.Parse(Console.ReadLine());
            double cost = squareM * 7.61;
            double discount = cost * 0.18;
            double finalPrice = cost - discount;

            Console.WriteLine($"The final price is {finalPrice}.");
            Console.WriteLine($"The discount is {discount}.");



        }
    }
}
