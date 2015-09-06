using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;

namespace BLL
{
    public class RoleInfoService :IRoleInfoService
    {

        public UserInfo GetUser(int id)
        {
            return new UserInfo() {Id = id,UName = "llllll"};
        }
    }
}
