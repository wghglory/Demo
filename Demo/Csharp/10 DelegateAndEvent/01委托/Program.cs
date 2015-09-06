using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01委托
{
    class Program
    {
        static void Main(string[] args)
        {
            //2. 使用委托：
            //    声明委托变量
            //    当声明委托变量后，如果不赋值则委托变量为null，所以在使用前校验weituo！=null
            //    委托类型的变量只能赋值一个委托类型的对象

            MyDelegate md = new MyDelegate(M1);      //md委托保存了M1方法。
            MyDelegate mdShort = M1;  //编译器给new，这种简写方式
            if (md != null)
            {
                md();  //简写
                md.Invoke();  //调用md委托的时候就相当于调用了M1方法。
            }      
        }

        static void M1()
        {
            Console.Write("M1 function");
            Console.ReadKey();
        }
    }

    //1.委托是一种数据类型，一般直接在命名空间定义。
    //定义委托是需指明返回值类型、委托名和参数列表。这样就能确定该类型的委托可存储的方法。
    public delegate void MyDelegate();

    public class MyClass
    {
        public void Say()
        {
            //..................
            //    .....这里占了委托，变化的方法....
            //    .........
        }
    }
}
