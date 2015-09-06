using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorDLL
{
    public class JianFaDll : Calculator
    {
        public JianFaDll()
        {

        }

        public JianFaDll(double d1, double d2)
            : base(d1, d2)
        {

        }
        public override double JiSuan()
        {
            return this.Number1 - this.Number2;
        }
    }
}
