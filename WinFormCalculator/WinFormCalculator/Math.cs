﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormCalculator
{
    public class Math : ICalculator
    {
        public double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        public double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        public double Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }
            return num1 / num2;
        }
    }
}
