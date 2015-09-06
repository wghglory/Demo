using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoneZizzorsCloth
{
    public class ComputerUser
    {
        //用来保存计算机出拳结果的属性
        public string FistName
        {
            get;
            set;
        }

        //计算机的出拳方法
        public int ShowFist()
        {
            Random random = new Random();
            int r = random.Next(1, 4);
            //1 石头
            //2 剪刀
            //3 布
            switch (r)
            {
                case 1:
                    this.FistName = "石头";
                    break;
                case 2:
                    this.FistName = "剪刀";
                    break;
                case 3:
                    this.FistName = "布";
                    break;
            }
            return r;
        }
    }
}
