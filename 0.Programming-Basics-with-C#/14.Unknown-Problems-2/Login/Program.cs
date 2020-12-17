using System;
using System.Globalization;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            string passwordInput = Console.ReadLine();
            int wrongPassCounter = 0;

            while (password != passwordInput)
            {
                wrongPassCounter++;

                if (wrongPassCounter < 4)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
                else
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }

                passwordInput = Console.ReadLine();
            }

            if (password == passwordInput)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
