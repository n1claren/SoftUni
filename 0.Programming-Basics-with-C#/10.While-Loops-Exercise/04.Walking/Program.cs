using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;

            int steps = 0;

            while (steps < goal)
            {
                string addstep = Console.ReadLine();

                if (addstep != "Going home")
                {
                    steps += int.Parse(addstep);
                }
                else if (addstep == "Going home")
                {
                    int homeWalkingSteps = int.Parse(Console.ReadLine());
                    steps += homeWalkingSteps;
                    break;
                }

            }

            if (steps > goal)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{steps - goal} steps over the goal!");
            }

            else
            {
                Console.WriteLine($"{goal - steps} more steps to reach goal.");
            }
        }
    }
}
