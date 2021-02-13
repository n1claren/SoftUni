﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.Comparing_Objects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public int CompareTo(Person other)
        {
            var nameComparrison = this.name.CompareTo(other.name);
            var ageComparrison = this.age.CompareTo(other.age);
            var townComparrison = this.town.CompareTo(other.town);

            if (nameComparrison != 0)
            {
                return nameComparrison;
            }
            else if (ageComparrison != 0)
            {
                return ageComparrison;
            }
            else
            {
                return townComparrison;
            }
        }

    }
}
