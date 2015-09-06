using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stu.Model;
using sc0802.Dal;
using _01三层.Tools;

namespace sc0802.Bll
{
    public class Aspx_UserBll
    {
        private Aspx_UserDal dal = new Aspx_UserDal();
        public Aspx_User GetUserInfo(string uid, string pwd)
        {
            return dal.GetUserInfo(uid, CommonHelper.GetMd5StringFromString(pwd));
        }

        public int CheckUserExists(string uid)
        {
            return dal.CheckUserExists(uid);
        }
    }
}
