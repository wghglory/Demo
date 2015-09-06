using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _08使用三层实现年龄长1岁.DAL;
using _08使用三层实现年龄长1岁.Tools;
using _08使用三层实现年龄长1岁.Model;

namespace _08使用三层实现年龄长1岁.BLL
{
    /// <summary>
    /// 操作T_Seats表的业务逻辑层类
    /// </summary>
    public class TSeatsBll
    {
        TSeatsDal dal = new TSeatsDal();

        public bool ValidUserLogin(string uid, string pwd)
        {
            return dal.ValidUserLogin(uid, CommonHelper.GetMd5StringFromString(pwd)) > 0;
        }

        public LoginResult CheckUserLogin(string uid, string pwd, out string userName, out int autoId)
        {
            userName = null;
            autoId = -1;

            //1.根据用户登录名查询用户的基本信息
            T_Seat model = dal.GetUserInfoByLoginId(uid);
            if (model == null)
            {
                return LoginResult.UserNotExists;
            }
            else if (model.CC_LoginPassword == CommonHelper.GetMd5StringFromString(pwd))
            {
                userName = model.CC_UserName;
                autoId = model.CC_AutoId;
                return LoginResult.Ok;
            }
            else
            {
                return LoginResult.ErrorPassword;
            }
        }

    }

    public enum LoginResult
    {
        UserNotExists,//用户不存在
        ErrorPassword,
        Ok
    }
}
