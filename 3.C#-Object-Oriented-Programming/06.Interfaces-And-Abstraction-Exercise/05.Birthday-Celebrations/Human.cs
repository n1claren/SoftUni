﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Birthday_Celebrations
{
    class Human : IIdentifiable, IMammmal, IBirthable
    {
        public Human(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
        public string Id { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Birthdate { get; private set; }
    }
}
