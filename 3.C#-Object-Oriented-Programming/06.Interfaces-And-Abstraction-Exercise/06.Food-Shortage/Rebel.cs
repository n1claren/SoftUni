﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Food_Shortage
{
    public class Rebel : IMammmal, IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Food = 0;
            Group = group;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int Food { get; private set; }

        public string Group { get; private set; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
