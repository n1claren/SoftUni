using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> scale = new EqualityScale<int>(5, 5);
            
            EqualityScale<int> scaleTwoPointO = new EqualityScale<int>(5, 6);

            Console.WriteLine(scale.AreEqual());

            Console.WriteLine(scaleTwoPointO.AreEqual());
        }
    }
}
