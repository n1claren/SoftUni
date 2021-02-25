using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Cat sara = new Cat();

            sara.Eat();
            sara.Meow();

            Dog marko = new Dog();

            marko.Eat();
            marko.Bark();
        }
    }
}
