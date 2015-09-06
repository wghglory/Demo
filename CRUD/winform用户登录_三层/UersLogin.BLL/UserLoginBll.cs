using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin.DAL;
using UsersLogin.Tools;

namespace UersLogin.BLL
{
    public static class userId
    {
        public static int Id { get; set; }
    }


    public class UserLoginBll
    {

        UserLoginAdl userDal = new UserLoginAdl();
        /// <summary>
        /// 用户登录
        /// </summary>
        public LoginResult GetLoginInfo(string loginId, string loginPwd)
        {
            //把字符串密码转换成 MD5
            string pwd = MD5Handle.StringConventMD5(loginPwd);
            Users user = userDal.GetUsersData(loginId);
            userId.Id = user.ID;
            if (user != null)
            {
                if (pwd != user.Pwd)
                {
                    return LoginResult.PasswordError;
                }
                else
                {
                    return LoginResult.Succeed;
                }
            }
            else
            {
                return LoginResult.LoginNonExistent;
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="OldPassword"></param>
        /// <param name="newPassword1"></param>
        /// <param name="newPassword2"></param>
        /// <returns></returns>
        public ChangePasswordResult ChangePassword(string OldPassword, string newPassword1, string newPassword2)
        {
            OldPassword = MD5Handle.StringConventMD5(OldPassword);
            newPassword1 = MD5Handle.StringConventMD5(newPassword1);
            newPassword2 = MD5Handle.StringConventMD5(newPassword2);
            if (newPassword1 == newPassword2)
            {
                int count = userDal.GetOldPasswordIsError(userId.Id, OldPassword);

                if (count > 0)
                {
                    int num = userDal.ChangePassword(userId.Id, newPassword1);

                    return ChangePasswordResult.Succeed;

                }
                else
                {
                    return ChangePasswordResult.oldPasswordError;
                }

            }
            else
            {
                return ChangePasswordResult.newPasswordDissimilarity;
            }
        }

        public enum LoginResult
        {
            LoginNonExistent,
            PasswordError,
            Succeed
        }

        public enum ChangePasswordResult
        {
            newPasswordDissimilarity,
            oldPasswordError,
            Succeed
        }
    }
}
