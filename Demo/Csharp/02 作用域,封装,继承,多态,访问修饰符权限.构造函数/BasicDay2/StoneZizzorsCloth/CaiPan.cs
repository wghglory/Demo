using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoneZizzorsCloth
{
    public class CaiPan
    {
        public string IsUserWin(int user, int computer)
        {
            if (user - computer == 0)
            {
                return "平局";
            }
            else if (user - computer == -1 || user - computer == 2)
            {
                return "用户赢了";
            }
            else
            {
                return "输了";
            }
        }
    }
}
