using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _01通过ado.net实现简单登录;
using System.Data.SqlClient;
using Stu.Model;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;

namespace _04数据库数据与Excel的导入导出
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //把T_Seats表中的数据导出到Excel文件
        private void button1_Click(object sender, EventArgs e)
        {
            #region 使用DataTable读取数据
            //string sql = "select * from T_Seats";
            ////1.把表中的数据读取出来
            //DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text);
            ////2.遍历dt中的每条数据
            //foreach (DataRow dr in dt.Rows)
            //{
            //    //===输出当前行的所有列===================================================
            //    //获取当前行的每一列dt.Columns.Count
            //    for (int i = 0; i < dt.Columns.Count; i++)
            //    {
            //        //输出当前行的每一列的数据
            //        Console.Write(dr[i] + "\t");
            //    }
            //    //===========================================================
            //    Console.WriteLine();
            //}

            #endregion

            #region 使用SqlDataReader读取数据并导出到Excel
            string sql = "select * from T_Seats";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text))
            {
                if (reader.HasRows)
                {

                    //创建一个Workbook
                    using (Workbook wk = new HSSFWorkbook())
                    {
                        //创建一个Sheet
                        using (Sheet sheet = wk.CreateSheet("T_Seats"))
                        {
                            int rowIndex = 0;
                            //循环创建每一行
                            while (reader.Read())
                            {
                                //CC_AutoId, CC_LoginId, CC_LoginPassword, CC_UserName, CC_ErrorTimes, CC_LockDateTime, CC_TestInt
                                TSeats model = new TSeats();
                                model.CC_AutoId = reader.GetInt32(0);
                                model.CC_LoginId = reader.GetString(1);
                                model.CC_LoginPassword = reader.GetString(2);
                                model.CC_UserName = reader.GetString(3);
                                model.CC_ErrorTimes = reader.GetInt32(4);
                                model.CC_LockDateTime = reader.IsDBNull(5) ? null : (DateTime?)reader.GetDateTime(5);
                                model.CC_TestInt = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6);

                                #region 创建行，并向该行中创建单元格

                                //将数据写入到Excel
                                Row row = sheet.CreateRow(rowIndex);
                                //向当前行中创建单元格
                                row.CreateCell(0).SetCellValue(model.CC_AutoId);
                                row.CreateCell(1).SetCellValue(model.CC_LoginId);
                                row.CreateCell(2).SetCellValue(model.CC_LoginPassword);
                                row.CreateCell(3).SetCellValue(model.CC_UserName);
                                row.CreateCell(4).SetCellValue(model.CC_ErrorTimes);


                                //对于空值的特殊处理
                                Cell cellLockDateTime = row.CreateCell(5);
                                if (model.CC_LockDateTime == null)
                                {
                                    cellLockDateTime.SetCellType(CellType.BLANK);
                                }
                                else
                                {
                                    cellLockDateTime.SetCellValue((DateTime)model.CC_LockDateTime);

                                    CellStyle cellStyle = wk.CreateCellStyle();
                                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("m/d/yy h:mm");
                                    cellLockDateTime.CellStyle = cellStyle;
                                }

                                Cell cellTestInt = row.CreateCell(6);
                                if (model.CC_TestInt == null)
                                {
                                    cellTestInt.SetCellType(CellType.BLANK);
                                }
                                else
                                {
                                    cellTestInt.SetCellValue((int)model.CC_TestInt);
                                }

                                #endregion

                                rowIndex++;


                                #region 将数据输出到控制台
                                //测试数据读取没有问题
                                //Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", model.CC_AutoId, model.CC_LoginId, model.CC_LoginPassword, model.CC_UserName, model.CC_ErrorTimes, model.CC_LockDateTime, model.CC_TestInt);
                                #endregion




                            }

                            //把Workbook写入到Excel中
                            //new FileStream("",FileMode.Append,FileAccess.Write)
                            using (FileStream fsWrite = File.OpenWrite("tseats.xls"))
                            {
                                wk.Write(fsWrite);
                            }
                        }
                    }
                }
            }
            #endregion

            MessageBox.Show("导出成功！");
        }
    }
}
