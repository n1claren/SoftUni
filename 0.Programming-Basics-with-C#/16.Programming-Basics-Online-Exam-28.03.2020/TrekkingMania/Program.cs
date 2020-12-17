using System;

namespace TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());

            int people = 0;

            int MusalaGroups = 0;
            int MonblanGroups = 0;
            int KilimandjaroGroups = 0;
            int K2Groups = 0;
            int EverestGroups = 0;

            int peopleTotal = 0;

            int MusalaPeople = 0;
            int MonblanPeople = 0;
            int KilimandjaroPeople = 0;
            int K2People = 0;
            int EverestPeople = 0;


            for (int i = 1; i <= groups; i++)
            {
                people = int.Parse(Console.ReadLine());
               
                if (people <= 5)
                {
                    MusalaGroups++;
                    MusalaPeople += people;
                }
                else if (people >= 6 && people <= 12)
                {
                    MonblanGroups++;
                    MonblanPeople += people;
                }
                else if (people >= 13 && people <= 25)
                {
                    KilimandjaroGroups++;
                    KilimandjaroPeople += people; 
                }
                else if (people >= 26 && people <= 40)
                {
                    K2Groups++;
                    K2People += people;
                }
                else if (people >= 41)
                {
                    EverestGroups++;
                    EverestPeople += people;
                }

                peopleTotal += people;

            }



            double musalaPercentage = (MusalaPeople * 1.0 / peopleTotal) * 100;
            double monblanPercentage = (MonblanPeople * 1.0 / peopleTotal) * 100;
            double kilimandjaroPercentage = (KilimandjaroPeople * 1.0 / peopleTotal) * 100;
            double k2Percentage = (K2People * 1.0 / peopleTotal) * 100;
            double everestPercentage = (EverestPeople * 1.0 / peopleTotal) * 100;

            Console.WriteLine($"{musalaPercentage:F2}%");
            Console.WriteLine($"{monblanPercentage:F2}%");
            Console.WriteLine($"{kilimandjaroPercentage:F2}%");
            Console.WriteLine($"{k2Percentage:F2}%");
            Console.WriteLine($"{everestPercentage:F2}%");

        }
    }
}
