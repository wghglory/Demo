using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ajax.CRUD.DAL;
using Ajax.CRUD.Model;
using Ajax.CRUD.Utility;

namespace Ajax.CRUD.BLL
{
    public class Aspx_UserBll
    {

        private Aspx_UserDal dal = new Aspx_UserDal();
        public Aspx_User GetUserInfo(string uid, string pwd)
        {
            return dal.GetUserModelByUidPwd(uid, CommonHelper.GetMD5FromString(pwd));
        }

        //检查用户名是否存在
        public bool CheckUserExists(string loginId)
        {
            return dal.CheckUserExists(loginId) > 0;
        }
    }
}
