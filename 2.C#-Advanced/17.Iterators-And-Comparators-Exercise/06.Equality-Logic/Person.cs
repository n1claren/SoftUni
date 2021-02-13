using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _06.Equality_Logic
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Person other)
        {
            var nameComparrison = this.name.CompareTo(other.name);
            var ageComparrison = this.age.CompareTo(other.age);

            if (nameComparrison != 0)
            {
                return nameComparrison;
            }
            else 
            {
                return ageComparrison;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Person other)
            {
                return this.name == other.name && this.age == other.age;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode() + this.age.GetHashCode();
        }
    }
}
