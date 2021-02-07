using System;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> generic = new Box<string>();
                
            generic.Add("Judge");
            generic.Add("is");
            generic.Add("extra gay");

            Console.WriteLine(generic.Remove());

            Console.WriteLine(generic.Count);

            Console.WriteLine(generic.Remove());

            Console.WriteLine(generic.Count);
        }
    }
}
