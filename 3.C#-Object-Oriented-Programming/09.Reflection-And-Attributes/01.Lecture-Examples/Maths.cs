using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Lecture_Examples
{
    public class Maths
    {
        public static int Add (int num1, int num2)
        {
            return num1 + num2;
        }

        public double Subtract (double a, double b)
        {
            return a - b;
        }

        protected long Multiply (long firstNum, long secondNum)
        {
            return firstNum * secondNum;
        }

        public virtual double Percentage(double numberOne, double numberTwo)
        {
            return (numberOne / numberTwo) * 100;
        }

        private double Divide(double dividerOne, double dividerTwo)
        {
            return dividerOne / dividerTwo;
        }
    }
}
