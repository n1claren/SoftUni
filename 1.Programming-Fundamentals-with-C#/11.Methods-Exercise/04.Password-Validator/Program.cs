using System;

namespace _04.Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if (PasswordLenghtCheck(password) == true &
                PasswordSymbolCheck(password) == true &
                PasswordDigitCounter(password) == true)
            {
                Console.WriteLine("Password is valid");
            }

            if (PasswordLenghtCheck(password) == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (PasswordSymbolCheck(password) == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (PasswordDigitCounter(password) == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

        }

        static bool PasswordLenghtCheck(string text)
        {
            if (text.Length >= 6 && text.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool PasswordSymbolCheck(string text)
        {
            int forbiddenSymbols = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]) == false)
                {
                    if (char.IsDigit(text[i]) == false)
                    {
                        forbiddenSymbols++;
                    }
                }
            }

            if (forbiddenSymbols > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool PasswordDigitCounter(string text)
        {
            int digitCounter = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]) == true)
                {
                    digitCounter++;
                }
            }

            if (digitCounter >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
