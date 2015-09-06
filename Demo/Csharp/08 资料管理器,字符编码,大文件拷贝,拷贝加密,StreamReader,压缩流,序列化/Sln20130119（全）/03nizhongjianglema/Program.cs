using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03nizhongjianglema
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random(); 
            while (true)
            {

                List<int> list = new List<int>();
                
                
                for (int i = 0; i < 6; i++)
                {
                    int redNum = r.Next(1, 34);                    
                    if (list.Contains(redNum))
                    {
                        i--;
                    }
                    else
                    {
                        list.Add(redNum);
                    }
                }
                
                for (int i = 0; i < list.Count; i++)
                {
                    Console.Write(list[i] + " ");
                }
                int blueNume = r.Next(1, 17);
                Console.WriteLine(blueNume);
                Console.ReadLine();
            }
            //03 21 02 06 22 18 10
        }
    }
}
