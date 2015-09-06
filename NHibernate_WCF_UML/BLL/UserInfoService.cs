using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;

namespace BLL
{
    public class UserInfoService :IUserInfoService
    {
        public string Show()
        {
            Console.WriteLine("shit");
            return DateTime.Now.ToString();
        }


        public UserInfo GetUserInfo(string userId)
        {
            return new UserInfo() {Id = int.Parse(userId),UName = DateTime.Now.ToString()};
        }
    }
}
