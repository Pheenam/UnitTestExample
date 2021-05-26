using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestExample
{
    public class Calculator
    {
        public double Addition(double x, double y)
        {
            var sum = 0.0;
            sum = x + y;
            Console.WriteLine("Addition Class Ans - " + sum.ToString());
            if (sum > 1000)
            {
                throw new Exception("Too Large");
            }
            return sum;
        }
    }
}
