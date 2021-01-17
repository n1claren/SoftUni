using System;
using System.Collections.Generic;

namespace _09.Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int operations = int.Parse(Console.ReadLine());

            string text = string.Empty;

            Stack<string> actions = new Stack<string>();

            for (int i = 0; i < operations; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];

                switch (command)
                {
                    case "1":
                        text += input[1];
                        actions.Push("1 " + input[1]);
                        break;

                    case "2":
                        int elementsToRemove = int.Parse(input[1]);

                        if (elementsToRemove >= text.Length)
                        {
                            actions.Push("2 " + text);
                            text = string.Empty;
                        }
                        else
                        {
                            actions.Push("2 " + text.Substring(text.Length - elementsToRemove, elementsToRemove));
                            text = text.Substring(0, text.Length - elementsToRemove);
                        }
                        break;

                    case "3":
                        int textDisplayIndex = int.Parse(input[1]) - 1;

                        Console.WriteLine(text[textDisplayIndex]);
                        break;

                    case "4":
                        string[] action = actions.Pop().Split();

                        if (action[0] == "1")
                        {
                            string textToRemove = action[1];

                            text = text.Remove(text.Length - textToRemove.Length, textToRemove.Length);
                        }

                        if (action[0] == "2")
                        {
                            string textToAdd = action[1];

                            text += textToAdd;
                        }
                        break;
                }
            }
        }
    }
}
