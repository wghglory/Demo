using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoneZizzorsCloth
{
    public class UserPlayer
    {
        public string FistName
        {
            get;
            set;
        }

        //玩家的出拳方法
        public int ShowFist(string fist)
        {

            //1 石头
            //2 剪刀
            //3 布

            this.FistName = fist;
            int result = -1;
            switch (fist)
            {
                case "石头":
                    result = 1;
                    break;
                case "剪刀":
                    result = 2;
                    break;
                case "布":
                    result = 3;
                    break;
            }
            return result;
        }
    }
}
