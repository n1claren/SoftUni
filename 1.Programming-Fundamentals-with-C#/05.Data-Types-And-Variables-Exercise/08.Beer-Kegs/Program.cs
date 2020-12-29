using System;

namespace _08.Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string biggestKeg = "";
            float biggestKegVolume = 0.0F;

            for (int i = 1; i <= n; i++)
            {
                string kegModel = Console.ReadLine();
                float kegRadius = float.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());

                float volume = (float)Math.PI * kegRadius * kegRadius * kegHeight;

                if (volume > biggestKegVolume)
                {
                    biggestKeg = kegModel;
                    biggestKegVolume = volume;
                }
            }

            Console.WriteLine(biggestKeg);
        }
    }
}
