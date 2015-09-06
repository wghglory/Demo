using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 委托
{
    //类中定义了委托，然后类中方法把委托作为参数。
    //调用该类的时候传递不同的方法
    public class DoSomething
    {
        public void Write(WriteTimeDelegate write)
        {
            Console.WriteLine("=============");
            Console.WriteLine("=============");
            if (write != null)
            {
                write.Invoke();
            }
            Console.WriteLine("=============");
            Console.WriteLine("=============");
        }

        public void ChangeStrings(string[] strs, GetStringDelegate change)   //3.传递委托给想要变化的方法；在这之前要把某些方法传递给委托
        {
            for (int i = 0; i < strs.Length; i++)
            {
                strs[i] = change(strs[i]);   //调用委托，其实就是调里面存的方法
            }
        }
    }

    //1.定义委托
    public delegate string GetStringDelegate(string name);
    public delegate void WriteTimeDelegate();
}
