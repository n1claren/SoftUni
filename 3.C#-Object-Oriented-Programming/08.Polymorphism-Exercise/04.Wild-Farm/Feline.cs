using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Wild_Farm
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }

        public override void Sound()
        {

        }
    }
}