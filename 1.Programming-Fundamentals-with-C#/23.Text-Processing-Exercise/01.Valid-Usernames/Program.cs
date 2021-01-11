using System;
using System.Collections.Generic;

namespace _01.Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");

            List<string> validUsernames = new List<string>();

            for (int i = 0; i < usernames.Length; i++)
            {
                if (usernames[i].Length >= 3 && usernames[i].Length <= 16)
                {
                    bool isLegit = true;

                    for (int j = 0; j < usernames[i].Length; j++)
                    {
                        if (Char.IsDigit(usernames[i][j]) == false
                            && Char.IsLetter(usernames[i][j]) == false
                            && usernames[i][j] != '_'
                            && usernames[i][j] != '-')
                        {
                            isLegit = false;
                        }
                    }

                    if (isLegit)
                    {
                        validUsernames.Add(usernames[i]);
                    }
                }
            }

            for (int z = 0; z < validUsernames.Count; z++)
            {
                Console.WriteLine(validUsernames[z]);
            }
        }
    }
}