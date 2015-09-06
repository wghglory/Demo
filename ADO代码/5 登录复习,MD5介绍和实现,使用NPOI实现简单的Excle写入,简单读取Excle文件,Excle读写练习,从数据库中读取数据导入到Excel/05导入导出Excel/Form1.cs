using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Itcast.Cn;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Collections;

namespace _01导入导出Excel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //将T_Seats表中的数据导出
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from T_Seats";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text))
            {
                if (reader.HasRows)
                {

                    //导出Excel代码
                    //创建Workbook
                    IWorkbook wk = new HSSFWorkbook();
                    //创建Sheet
                    ISheet sheet = wk.CreateSheet("T_Seats");
                    int rowIndex = 0;
                    //循环创建每一行
                    while (reader.Read())
                    {
                        //每次读取到一行就创建一个Row
                        IRow row = sheet.CreateRow(rowIndex);
                        rowIndex++;


                        ////reader.GetName(colIndex);//根据列的索引获取列的名称

                        ////reader.FieldCount
                        //for (int col = 0; col < reader.FieldCount; col++)
                        //{
                        //    //reader.GetValue(col);
                        //    switch (reader.GetDataTypeName(col))
                        //    {
                        //        case "char":
                        //        case "varchar":
                        //        case "nvarchar":
                        //        case "nchar":
                        //            reader.GetString(col);
                        //            break;
                        //        case "int":
                        //        case "smallint":
                        //            reader.GetInt32(col);
                        //            break;
                        //        case "datetime":
                        //            reader.GetDateTime(col);
                        //            break;
                        //        case "bit":
                        //            reader.GetBoolean(col);
                        //            break;
                        //        default:
                        //            break;
                        //    }
                        //}


                        //获取每一列的值
                        //CC_AutoId, CC_LoginId, CC_LoginPassword, CC_UserName, CC_ErrorTimes, CC_LockDateTime, CC_TestInt
                        int autoId = reader.GetInt32(0);
                        string uid = reader.GetString(1);
                        string pwd = reader.GetString(2);
                        string name = reader.GetString(3);
                        int errorTimes = reader.GetInt32(4);//错误次数
                        DateTime? lockTime = reader.IsDBNull(5) ? null : (DateTime?)reader.GetDateTime(5);
                        int? testInt = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6);

                        //为每行创建单元格
                        row.CreateCell(0).SetCellValue(autoId);
                        row.CreateCell(1).SetCellValue(uid);
                        row.CreateCell(2).SetCellValue(pwd);
                        row.CreateCell(3).SetCellValue(name);
                        row.CreateCell(4).SetCellValue(errorTimes);


                        //对于可能为空的单元格，要先创建再赋值
                        ICell cellLockTime = row.CreateCell(5);
                        if (lockTime == null)
                        {
                            cellLockTime.SetCellType(CellType.BLANK);
                        }
                        else
                        {
                            cellLockTime.SetCellValue((DateTime)lockTime);
                            ICellStyle cellStyle = wk.CreateCellStyle();
                            cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("m/d/yy h:mm");
                            cellLockTime.CellStyle = cellStyle;
                            
                        }

                        ICell cellTestInt = row.CreateCell(6);
                        if (testInt == null)
                        {
                            cellTestInt.SetCellType(CellType.BLANK);
                        }
                        else
                        {
                            cellTestInt.SetCellValue((int)testInt);
                        }

                        // Console.WriteLine("{0}-{1}-{2}-{3}-{4}-{5}-{6}", autoId, uid, pwd, name, errorTimes, lockTime, testInt);
                    }

                    //把数据写入到磁盘上
                    using (FileStream fs = File.OpenWrite("t1.xls"))
                    {
                        wk.Write(fs);
                        MessageBox.Show("ok");
                    }
                }
            }
        }


        //把t1.xls中的内容导入到数据库
        private void button2_Click(object sender, EventArgs e)
        {
            //1先读取Excle
            using (FileStream fsRead = File.OpenRead("t1.xls"))
            {
                //2.创建Workbook
                IWorkbook wk = new HSSFWorkbook(fsRead);
                //3.获取Sheet
                ISheet sheet = wk.GetSheetAt(0);
                string sql = "insert into T_Seats(CC_LoginId, CC_LoginPassword, CC_UserName, CC_ErrorTimes, CC_LockDateTime, CC_TestInt) values(@uid,@pwd,@name,@errorTimes,@lockTime,@testInt)";


                #region 读取所有行
                //4.获取当前工作表中的所有的行
                for (int i = 0; i <= sheet.LastRowNum; i++)
                {
                    SqlParameter[] pms = new SqlParameter[] { 
                    new SqlParameter("@uid",SqlDbType.NVarChar,50),
                    new SqlParameter("@pwd",SqlDbType.VarChar,50),
                    new SqlParameter("@name",SqlDbType.NVarChar,50),
                    new SqlParameter("@errorTimes",SqlDbType.Int),
                    new SqlParameter("@lockTime",SqlDbType.Decimal),
                    new SqlParameter("@testInt",SqlDbType.Int)
                    };
                    //获取某行
                    IRow currentRow = sheet.GetRow(i);
                    if (currentRow != null)
                    {

                        #region 读取行的每一列
                        //读取该行中的所有的单元格
                        //从第一个单元格开始获取
                        for (int c = 1; c < currentRow.LastCellNum; c++)
                        {
                            //获取每个单元格的内容
                            ICell cell = currentRow.GetCell(c);
                            if (cell == null || cell.CellType == CellType.BLANK)
                            {
                                //向数据库中插入一个DBNull.Value
                                pms[c - 1].Value = DBNull.Value;
                            }
                            else
                            {
                                //如果当前单元格不为空，则根据单元格的类型获取数据
                                switch (cell.CellType)
                                {
                                    //只有当单元格的数据类型是数字类型的时候使用cell.NumericCellValue来获取值。其余类型都使用字符串来获取.日期类型数据插入单元格后也是CellType.NUMERIC
                                    case CellType.NUMERIC:
                                        //cell.NumericCellValue;
                                        pms[c - 1].Value = cell.NumericCellValue;
                                        break;                                                                         
                                    default:
                                        //cell.ToString();
                                        pms[c - 1].Value = cell.ToString();
                                        break;
                                }
                            }

                        }
                        #endregion

                    }

                    //没读取一行数据执行一次插入语句
                    SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms);
                }

                MessageBox.Show("ok");
                #endregion


            }
        }
    }
}

//遍历行
//IEnumerator rows= sheet.GetRowEnumerator();
//while (rows.MoveNext())
//{
//    rows.Current;

//}