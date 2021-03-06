using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Border_Control
{
    class Human : IIdentifiable, IHuman
    {
        public Human(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }
        public string Id { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }
    }
}
