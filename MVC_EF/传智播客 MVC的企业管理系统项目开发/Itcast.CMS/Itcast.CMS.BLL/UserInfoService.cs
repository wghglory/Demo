using Itcast.CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itcast.CMS.BLL
{
    public class UserInfoService
    {
        DAL.UserInfoDal userInfoDal = new DAL.UserInfoDal();
        public T_UserInfo GetUserInfoModel(string userName, string userPwd)
        {
            return userInfoDal.GetUserInfoModel(userName, userPwd);
        }
    }
}
