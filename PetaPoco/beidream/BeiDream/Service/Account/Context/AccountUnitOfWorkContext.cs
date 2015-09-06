using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeiDream.Framework.Data;
using BeiDream.Framework.Common;

namespace BeiDream.Service.Account
{
    public class AccountUnitOfWorkContext : PetaPocoUnitOfWorkBase,IDependency
    {
        //通过配置文件切换数据库(MySql暂未测试)
        string connectionName = AppSettingsHelper.GetString("AccountDB");
        /// <summary>
        /// 获取当前使用的数据访问上下文对象
        /// </summary>
        protected override Database DBContext
        {
            get { return AccountDbContext; }
        }

        /// <summary>
        /// 获取或设置 项目数据访问上下文对象
        /// </summary>
        public Database AccountDbContext
        {
            get { return new Database(connectionName); } 
            set { this.AccountDbContext = value; } 
        }

    }
}
