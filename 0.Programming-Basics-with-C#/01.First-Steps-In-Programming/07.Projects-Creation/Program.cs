using System;

namespace ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string architect = Console.ReadLine();
            int projects = int.Parse(Console.ReadLine());
            int time = projects * 3;
            Console.WriteLine($"The architect {architect} will need {time} hours to complete {projects} project/s.");




        }
    }
}
