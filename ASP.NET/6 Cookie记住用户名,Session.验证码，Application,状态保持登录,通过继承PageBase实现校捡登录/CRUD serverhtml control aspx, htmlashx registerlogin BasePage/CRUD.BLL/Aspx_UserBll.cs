using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stu.Model;
using CRUD.DAL;
using _01三层.Tools;

namespace CRUD.BLL
{
    public class Aspx_UserBll
    {

        private Aspx_UserDal dal = new Aspx_UserDal();
        public Aspx_User GetUserInfo(string uid, string pwd)
        {
            return dal.GetUserModelByUidPwd(uid, CommonHelper.GetMd5StringFromString(pwd));
        }

    }
}
