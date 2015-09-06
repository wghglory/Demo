using CalculatorDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCalculator
{
    public class ChengFaClass : Calculator
    {
        public ChengFaClass()
        {

        }
        public ChengFaClass(double d1, double d2)
            : base(d1, d2)
        {

        }
        public override double JiSuan()
        {
            return this.Number1 * this.Number2;
        }
    }
}
