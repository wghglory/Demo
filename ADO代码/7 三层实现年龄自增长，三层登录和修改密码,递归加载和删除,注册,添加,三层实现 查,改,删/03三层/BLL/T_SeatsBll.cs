using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _01三层.DAL;
using _01三层.Model;
using _01三层.Tools;

namespace _01三层.BLL
{
    public class T_SeatsBll
    {
        public LoginResult CheckUserLogin(string loginId, string pwd, out string username, out int autoId)
        {
            username = string.Empty;
            autoId = -1;
            //1.先从数据库中查询
            T_SeatsDal dal = new T_SeatsDal();
            T_Seats model = dal.GetUserInfoByLoginId(loginId);
            if (model == null)
            {
                return LoginResult.UserNotExists;
            }
            else if (model.Password == CommonHelper.GetMd5StringFromString(pwd))
            {
                username = model.UserName;
                autoId = model.AutoId;
                return LoginResult.OK;
            }
            else
            {
                return LoginResult.ErrorPassword;
            }
        }


        //编写修改密码的方法
        public ChangePasswordResult ChangePassword(int autoId, string oldpwd, string newpwd1, string newpwd2)
        {
            //1.验证新密码
            if (newpwd1 == newpwd2)
            {
                //继续校验旧密码
                if (CheckOldPassword(autoId, oldpwd))
                {
                    try
                    {
                        //开始修改密码
                        UpdatePassword(autoId, newpwd1);
                        return ChangePasswordResult.OK;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("修改密码失败！！！", ex);
                    }
                }
                else
                {
                    return ChangePasswordResult.ErrorOldPwd;
                }
            }
            else
            {
                return ChangePasswordResult.DiffNewPwd;
            }
        }

        private void UpdatePassword(int autoId, string newpwd1)
        {
            T_SeatsDal dal = new T_SeatsDal();
            dal.UpdatePassword(autoId, CommonHelper.GetMd5StringFromString(newpwd1));
        }

        private bool CheckOldPassword(int autoId, string oldpwd)
        {

            //调用数据访问层来校验旧密码是否正确
            T_SeatsDal dal = new T_SeatsDal();
            return dal.CheckOldPassword(autoId, CommonHelper.GetMd5StringFromString(oldpwd)) > 0;
        }

        public AddUserState Add(T_Seats model, out int autoId)
        {
            autoId = -1;
            //1.校验用户名是否存在！
            T_SeatsDal dal = new T_SeatsDal();
            if (dal.CheckLoginIdExists(model.CC_LoginId) > 0)
            {
                return AddUserState.LoginIdExists;
            }
            else
            {
                model.Password = CommonHelper.GetMd5StringFromString(model.Password);
                autoId = dal.Add(model);
                return AddUserState.OK;
            }
        }
    }

    public enum AddUserState
    {
        LoginIdExists,
        OK
    }

    public enum ChangePasswordResult
    {
        DiffNewPwd,
        ErrorOldPwd,
        OK
    }

    public enum LoginResult
    {
        UserNotExists,
        ErrorPassword,
        OK
    }

}
