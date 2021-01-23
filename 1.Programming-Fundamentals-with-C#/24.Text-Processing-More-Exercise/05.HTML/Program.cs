using System;
using System.Collections.Generic;

namespace _05.HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            int counter = 0;

            List<string> htmlCode = new List<string>();

            while ((input = Console.ReadLine()) != "end of comments")
            {
                counter++;

                if (counter == 1)
                {
                    htmlCode.Add("<h1>");
                    htmlCode.Add(input);
                    htmlCode.Add("</h1>");
                }
                else if (counter == 2)
                {
                    htmlCode.Add("<article>");
                    htmlCode.Add(input);
                    htmlCode.Add("</article>");
                }
                else
                {
                    htmlCode.Add("<div>");
                    htmlCode.Add(input);
                    htmlCode.Add("</div>");
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, htmlCode));
        }
    }
}