using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Itcast.Cn;

namespace _08使用三层实现年龄长1岁.DAL
{

    //操作MyStudent表的数据访问层代码
    public class MyStudentDal
    {

        //update MyStudent set fage=fage+1

        public int AgeInc()
        {
            string sql = "update MyStudent set fage=fage+1";
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text);
        }


    }
}
