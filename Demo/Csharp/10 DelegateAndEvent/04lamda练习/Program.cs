using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04lamda练习
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 99, 1230, 324, 324, 564, 6, 32 };
            IEnumerable<int> result = list.Where(x => x > 7);   //where(Func<int,bool> predicate: x => x > 76)
            IEnumerable<int> result1 = list.Where(x => { return x > 7; });
            IEnumerable<int> result2 = list.Where(Condition);

            //Func<int, bool> predicate = x => x > 76;  x是int，返回x>76的bool结果
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        static bool Condition(int x)
        {
            return x > 6;
        }
    }
}
