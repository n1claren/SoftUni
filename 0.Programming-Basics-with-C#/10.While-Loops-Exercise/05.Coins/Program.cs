using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            double changeStotinki = Math.Floor(change * 100);

            double lev = Math.Floor(changeStotinki / 100);
            double stotinki = changeStotinki % 100;

            double coinCountLev = 0;
            double coinCountStotinki = 0;

            if (lev % 2 == 0)
            {
                coinCountLev = lev / 2;
            }
            else if (lev % 2 != 0)
            {
                coinCountLev = Math.Floor(lev / 2) + 1;
            }



            while (stotinki > 0)
            {
                if (stotinki >= 50)
                {
                    stotinki -= 50;
                    coinCountStotinki++;
                }

                if (stotinki >= 20)
                {
                    stotinki -= 20;
                    coinCountStotinki++;
                }

                if (stotinki >= 20)
                {
                    stotinki -= 20;
                    coinCountStotinki++;
                }

                if (stotinki >= 10)
                {
                    stotinki -= 10;
                    coinCountStotinki++;
                }

                if (stotinki >= 5)
                {
                    stotinki -= 5;
                    coinCountStotinki++;
                }

                if (stotinki >= 2)
                {
                    stotinki -= 2;
                    coinCountStotinki++;
                }

                if (stotinki >= 2)
                {
                    stotinki -= 2;
                    coinCountStotinki++;
                }

                if (stotinki >= 1)
                {
                    stotinki -= 1;
                    coinCountStotinki++;
                }

            }

            double coinCount = coinCountLev + coinCountStotinki;
            Console.WriteLine(coinCount);

        }
    }
}
