using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Puppy pup = new Puppy();

            pup.Bark();
            pup.Eat();
            pup.Weep();
        }
    }
}
