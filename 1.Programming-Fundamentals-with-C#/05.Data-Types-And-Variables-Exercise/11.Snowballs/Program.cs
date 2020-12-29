using System;
using System.Numerics;

namespace _11.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger snowballValue = 0;
            int snowballSnow = 0;
            int snowballTime = 0;
            int snowballQuality = 0;

            for (int i = 0; i < n; i++)
            {
                int temporalSnowballSnow = int.Parse(Console.ReadLine());
                int temporalSnowballTime = int.Parse(Console.ReadLine());
                int temporalSnowballQuality = int.Parse(Console.ReadLine());

                BigInteger temporalValue = 
                    BigInteger.Pow(temporalSnowballSnow / temporalSnowballTime, temporalSnowballQuality);

                if (snowballValue < temporalValue)
                {
                    snowballValue = temporalValue;
                    snowballSnow = temporalSnowballSnow;
                    snowballTime = temporalSnowballTime;
                    snowballQuality = temporalSnowballQuality;
                }
            }

            Console.WriteLine($"{snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})");

        }
    }
}
