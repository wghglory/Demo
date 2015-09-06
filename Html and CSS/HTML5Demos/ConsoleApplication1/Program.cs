using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal delegate int AddDel(int a, int b);

    delegate T MyFunc<T, T2>(T2 a);

    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine('d');

            //ThreadPool.QueueUserWorkItem(p.ShowData, 10);
            //ThreadPool.QueueUserWorkItem(p.ShowData, 3);

            //Parallel.For(0, 20, (index) =>
            //                        {
            //                            Console.WriteLine(index.ToString());
            //                        });


            AddDel delFun = delegate(int a, int b) { return a + b; };

            Console.WriteLine("fun--{0}", delFun(3, 5));


            AddDel delLambda = (int a, int b) =>
                                   {
                                       a++;
                                       b++;
                                       return a + b;
                                   };
            Console.WriteLine("fun--{0}", delLambda(3, 4));


            List<string> strList = new List<string>()
                                       {
                                           "1","2","4","9"
                                       };

            var temp = strList.FindAll(s => int.Parse(s) > 2);
            foreach (var str in temp)
            {
                Console.WriteLine(str);
            }


            Func<int, int> delFunc = delegate(int a)
            {
                return ++a;
            };



            Console.WriteLine(delFunc(9));

            Console.ReadKey();
        }

        public void ShowData(object numObj)
        {
            int num = (int)numObj;
            Console.WriteLine(DateTime.Now.ToString());

            for (int i = num - 1; i >= 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);

            }
        }
    }


}
