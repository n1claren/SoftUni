using System;
using System.Reflection.Metadata;

namespace GraduationPt2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int clazz = 1;
            double gradesum = 0;
            int repeatClazz = 0;
            bool graduates = true;


            while (clazz <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                gradesum += grade;

                if (grade >= 4)
                {
                    clazz++;
                    repeatClazz = 0;
                }
                else
                {
                    repeatClazz++;

                    if (repeatClazz == 2)
                    {
                        graduates = false;
                        break;
                    }
                    continue;
                }

            }

            double avgGrade = gradesum / (clazz-1);

            if (graduates)
            {
                Console.WriteLine($"{name} graduated. Average grade: {avgGrade:F2}");
            }
            else
            {
                Console.WriteLine($"{name} has been excluded at {clazz} grade");
            }
        }
    }
}
