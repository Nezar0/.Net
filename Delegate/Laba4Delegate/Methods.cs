using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate
{
    class Methods
    {
       public double Add(double x)
        {
            double ans = x + 5;
            Console.WriteLine("Операция сложения:" + ans);
            return ans;
        }
        public double Multiply(double x)
        {
            double ans = x * 7;
            Console.WriteLine("Операция умножения:" + ans);
            return ans;
        }
        public double Subtraction(double x)
        {
            double ans = x - 3;
            Console.WriteLine("Операция вычитания:" + ans);
            return ans;
        }
        public double Division(double x)
        {
            double ans = x / 3;
            Console.WriteLine("Операция деления без остатка:" + ans);
            return ans;
        }
        public double Pow(double x)
        {
            double ans = x * x;
            Console.WriteLine("Операция квадрата:" + ans);
            return ans;
        }

    }
}
