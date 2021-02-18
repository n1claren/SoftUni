using System;
using System.Collections.Generic;
using System.Text;

namespace VetClinic
{
    public class Pet
    {
        public Pet(string name, int age, string owner)
        {
            this.Age = age;
            this.Name = name;
            this.Owner = owner;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Owner { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} Age: {Age} Owner: {Owner}";
        }
    }
}
