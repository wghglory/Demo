using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRUD.DAL;
using CRUD.Model;

namespace CRUD.BLL
{
    public class UsersBll
    {
        UsersDal dal = new UsersDal();
        public bool CheckUserLogin(string loginId, string loginPwd)
        {
            return dal.CheckUserLogin(loginId, loginPwd) > 0;
        }

        public int Add(Users model)
        {
            return dal.Add(model);
        }

        public List<Users> GetAllUsers()
        {
            return dal.GetAllUsers();
        }
        public int Delete(int autoId)
        {
            return dal.Delete(autoId);
        }
        public Users GetUserInfoByAutoId(int autoId)
        {
            return dal.GetUserInfoByAutoId(autoId);
        }

        public int Update(Users model)
        {
            return dal.Update(model);
        }
    }
}
