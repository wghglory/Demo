using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace Homework.DAL
{
    public class SqlAndParamrter
    {
        public string Sql { get; set; }
        public SqlParameter[] Parameters { get; set; }
        public CommandType commandType { get; set; }
    }
}
