using System;

namespace DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            double depositDuration = double.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());
            double interest = percentage / 100 * deposit;
            double monthlyInterest = interest / 12;
            double totalInterest = depositDuration * monthlyInterest;
            double sumAfterDepositDuration = deposit + totalInterest;

            Console.WriteLine(sumAfterDepositDuration);

        }
    }
}
