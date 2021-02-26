using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Animal
    {
        private const string DEFAULT_GENDER = "Male";
        public Tomcat(string name, int age) 
            : base(name, age, DEFAULT_GENDER)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
