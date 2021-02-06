using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Raw_Data
{
    class Tire
    {
        public double TirePressure { get; set; }
        public int TireAge { get; set; }

        public Tire(double tirePressure, int tireAge)
        {
            this.TirePressure = tirePressure;
            this.TireAge = tireAge;
        }
    }
}
