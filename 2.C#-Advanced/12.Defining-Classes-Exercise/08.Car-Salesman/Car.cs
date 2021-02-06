using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Car_Salesman
{
    class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = 0;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public override string ToString()
        {
            string print;

            print = $"{this.Model}:" + Environment.NewLine;
            print += "  " + this.Engine.Model + ":" + Environment.NewLine;
            print += $"    Power: {this.Engine.Power}" + Environment.NewLine;

            if (this.Engine.Displacement == 0)
            {
                print += $"    Displacement: n/a" + Environment.NewLine;
            }
            else
            {
                print += $"    Displacement: {this.Engine.Displacement}" + Environment.NewLine;
            }

            print += $"    Efficiency: {this.Engine.Efficiency}" + Environment.NewLine;

            if (this.Weight == 0)
            {
                print += $"  Weight: n/a" + Environment.NewLine;
            }
            else
            {
                print += $"  Weight: {this.Weight}" + Environment.NewLine;
            }

            print += $"  Color: {this.Color}";

            return print;
        }
    }
}
