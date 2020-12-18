using System;

namespace OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string favBook = Console.ReadLine();

            string checkBook = Console.ReadLine();

            int bookCount = 0;

            while (checkBook != "No More Books")
            {

                if (favBook == checkBook)
                {
                    break;
                }

                bookCount++;
                checkBook = Console.ReadLine();
            }

            if (favBook == checkBook)
            {
                Console.WriteLine($"You checked {bookCount} books and found it.");
            }

            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {bookCount} books.");
            }
        }
    }
}
