using System;

namespace AuthorProblem
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tracker = new Tracker();

            tracker.PrintMethodsByAuthor();
        }

        [Author("n1claren")]
        public static void DoNothingButTestTracker()
        {
            Console.WriteLine("testing, testing, 1, 2, 3");
        }

        [Author("Nikolay")]
        public static int UselessCalculationMethodForTesting()
        {
            int a = 5;
            int b = 10;

            return a + b;
        }
    }


}
