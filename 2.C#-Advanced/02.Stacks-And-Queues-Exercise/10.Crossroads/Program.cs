using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main()
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> que = new Queue<string>();

            int carsPassed = 0;

            string trafficInfo = string.Empty;

            bool noCrash = true;

            while ((trafficInfo = Console.ReadLine()) != "END")
            {
                int greenTime = greenLight;
                int freeTime = freeWindow;

                if (trafficInfo == "green")
                {
                    while (greenTime > 0 && que.Count != 0)
                    {

                        string carPassing = que.Dequeue();

                        greenTime -= carPassing.Length;

                        if (greenTime >= 0)
                        {
                            carsPassed++;
                        }
                        else
                        {
                            freeTime += greenTime;

                            if (freeTime < 0)
                            {
                                Console.WriteLine("A crash happened!");

                                Console.WriteLine($"{carPassing} was hit at {carPassing[carPassing.Length + greenTime]}.");

                                noCrash = false;

                                break;
                            }

                            carsPassed++;
                        }
                    }
                }
                else
                {
                    que.Enqueue(trafficInfo);
                }
            }

            if (noCrash)
            {
                Console.WriteLine("Everyone is safe.");

                Console.WriteLine(carsPassed + " total cars passed the crossroads.");
            }
        }
    }
}