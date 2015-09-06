using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02计算器
{
    public class Calculator
    {
        public Calculator(double d1, double d2)
        {
            this.Number1 = d1;
            this.Number2 = d2;
        }

        public double Number1
        {
            get;
            set;
        }

        public double Number2
        {
            get;
            set;
        }

        //加法
        public double Add()
        {
            return Number1 + Number2;
        }

    }
}
