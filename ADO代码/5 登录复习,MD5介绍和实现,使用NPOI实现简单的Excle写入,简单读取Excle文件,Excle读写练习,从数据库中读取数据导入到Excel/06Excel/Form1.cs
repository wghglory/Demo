using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Homework.BLL;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using Homework.Model;
using System.Data.SqlClient;

namespace Homework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            BLL.CustomersManager bll = new CustomersManager();
            IWorkbook wk = new HSSFWorkbook();
            ISheet sheet = wk.CreateSheet("Customers");
            List<Customers> listCustomers = bll.GetAllReader();
            int rowIndex = 0;
            foreach (Customers item in listCustomers)
            {
                IRow row = sheet.CreateRow(rowIndex);
                rowIndex++;

                #region 加载到Row


                row.CreateCell(0).SetCellValue(item.CC_AutoId);
                if (item.CC_CustomerName == null)
                {
                    row.CreateCell(1).SetCellType(CellType.BLANK);
                }
                else
                {
                    row.CreateCell(1).SetCellValue(item.CC_CustomerName);
                }

                if (item.CC_CellPhone == null)
                {
                    row.CreateCell(2).SetCellType(CellType.BLANK);
                }
                else
                {
                    row.CreateCell(2).SetCellValue(item.CC_CellPhone);
                }
                if (item.CC_Landline == null)
                {
                    row.CreateCell(3).SetCellType(CellType.BLANK);
                }
                else
                {
                    row.CreateCell(3).SetCellValue(item.CC_Landline);
                }
                if (item.CC_Postcode == null)
                {
                    row.CreateCell(4).SetCellType(CellType.BLANK);
                }
                else
                {
                    row.CreateCell(4).SetCellValue(item.CC_Postcode);
                }
                if (item.CC_Email == null)
                {
                    row.CreateCell(5).SetCellType(CellType.BLANK);
                }
                else
                {
                    row.CreateCell(5).SetCellValue(item.CC_Email);
                }
                if (item.CC_Address == null)
                {
                    row.CreateCell(6).SetCellType(CellType.BLANK);
                }
                else
                {
                    row.CreateCell(6).SetCellValue(item.CC_Address);
                }

                if (item.CC_BranchId == null)
                {
                    row.CreateCell(7).SetCellType(CellType.BLANK);
                }
                else
                {
                    row.CreateCell(7).SetCellValue(item.CC_BranchId);
                }

                if (item.CC_BuyDate == null)
                {
                    row.CreateCell(8).SetCellType(CellType.BLANK);
                }
                else
                {
                    row.CreateCell(8).SetCellValue(item.CC_BuyDate.ToString());
                }
                if (item.CC_CarNum == null)
                {
                    row.CreateCell(9).SetCellType(CellType.BLANK);
                }
                else
                {
                    row.CreateCell(9).SetCellValue(item.CC_CarNum);
                }

                if (item.CC_BracketNum == null)
                {
                    row.CreateCell(10).SetCellType(CellType.BLANK);
                }
                else
                {
                    row.CreateCell(10).SetCellValue(item.CC_BracketNum);
                }
                if (item.CC_Brand == null)
                {
                    row.CreateCell(11).SetCellType(CellType.BLANK);
                }
                else
                {
                    row.CreateCell(11).SetCellValue(item.CC_Brand);
                }

                if (item.CC_TypeNum == null)
                {
                    row.CreateCell(12).SetCellType(CellType.BLANK);
                }
                else
                {
                    row.CreateCell(12).SetCellValue(item.CC_TypeNum);
                }

                if (item.CC_Suggestion == null)
                {
                    row.CreateCell(13).SetCellType(CellType.BLANK);
                }
                else
                {
                    row.CreateCell(13).SetCellValue(item.CC_Suggestion);
                }
                if (item.CC_Remarks == null)
                {
                    row.CreateCell(14).SetCellType(CellType.BLANK);
                }
                else
                {
                    row.CreateCell(14).SetCellValue(item.CC_Remarks);
                }

                #endregion
            }
            using (FileStream fsWrite = File.OpenWrite("24K.xls"))
            {
                wk.Write(fsWrite);
            }
            MessageBox.Show("OK");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FileStream fileStreamRead = new FileStream("new.xls", FileMode.Open))
            {
                //创建工作簿
                IWorkbook wk = new HSSFWorkbook(fileStreamRead);
                //获得工作表的个数
                int sheetCount = wk.NumberOfSheets;
                for (int i = 0; i < sheetCount; i++)
                {
                    //获得当前工作表
                    ISheet sheet = wk.GetSheetAt(i);
                    string strSql =
                        "insert into  T_Customers(CC_CustomerName, CC_CellPhone, CC_Landline,CC_CarNum ,CC_BracketNum,CC_BuyDate) values(@CC_CustomerName, @CC_CellPhone, @CC_Landline,@CC_CarNum ,@CC_BracketNum,@CC_BuyDate)";
                    //获取当前工作表的总行数
                    int rowCount = sheet.LastRowNum;
                    for (int j = 1; j <= rowCount; j++)
                    {
                        SqlParameter[] parameters = new SqlParameter[]
                                                      {
                                                          new SqlParameter("@CC_CustomerName", SqlDbType.NVarChar,50), 
                                                          new SqlParameter("@CC_CellPhone",SqlDbType.VarChar,50),
                                                          new SqlParameter("@CC_Landline",SqlDbType.VarChar,50),
                                                          new SqlParameter("@CC_CarNum",SqlDbType.VarChar,50),
                                                          new SqlParameter("@CC_BracketNum",SqlDbType.VarChar,50),
                                                          new SqlParameter("@CC_BuyDate",SqlDbType.DateTime), 
                                                      };

                        //获得当前行
                        IRow row = sheet.GetRow(j);
                        //获得当前行的单元格数
                        int cellCount = row.LastCellNum;
                        for (int k = 0; k < cellCount; k++)
                        {
                            //获得当前单元格
                            ICell cell = row.GetCell(k);

                            if (cell == null)
                            {
                                //当前单元格的数据为空 则给数据库传入空
                                parameters[k].Value = DBNull.Value;
                            }
                            else
                            {
                                //判断读到的数据类型
                                switch (cell.CellType)
                                {
                                    //数字类型
                                    case CellType.NUMERIC:
                                        if (k == 5)
                                        {
                                            parameters[k].Value = cell.DateCellValue;
                                        }
                                        else
                                        {
                                            parameters[k].Value = cell.NumericCellValue;
                                        }

                                        break;
                                    case CellType.BLANK:
                                        parameters[k].Value = DBNull.Value;
                                        break;
                                    default:
                                        parameters[k].Value = cell.ToString();
                                        break;
                                }
                            }
                        }
                        int r = Alian_SQL_Helper.SQL_Helper.ExecuteNonquery(strSql, CommandType.Text, parameters);
                    }
                }
            }
            MessageBox.Show("Test");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlDataReader reader = Alian_SQL_Helper.SQL_Helper.ExecuteReader(
                "select CC_AutoId, CC_CustomerName, CC_CellPhone, CC_Landline, CC_Postcode, CC_Email, CC_Address, CC_BranchId, CC_BuyDate, CC_CarNum, CC_BracketNum, CC_Brand, CC_TypeNum, CC_Suggestion, CC_Remarks from T_Customers",
                CommandType.Text))
            {
                if (reader.HasRows)
                {
                    //创建工作薄
                    IWorkbook wk = new HSSFWorkbook();

                    //创建工作表
                    ISheet sheet = wk.CreateSheet("24KB");
                    int num = 0;
                    while (reader.Read())
                    {
                        //创建行
                        IRow row = sheet.CreateRow(num);
                        //字段的长度
                        // reader.VisibleFieldCount;
                        //获取当前行中的列数
                        //  reader.FieldCount
                        //获取一个表示指定列中的数据类型的字符串
                        //reader.GetDataTypeName("")
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            //创建单元格
                            ICell cell = row.CreateCell(i);
                            if (reader.IsDBNull(i))
                            {
                                cell.SetCellType(CellType.BLANK);
                            }
                            else
                            {
                                switch (reader.GetDataTypeName(i))
                                {
                                    case "nvarchar":
                                    case "varchar":
                                        cell.SetCellType(CellType.STRING);
                                        cell.SetCellValue(reader.GetString(i));
                                        break;
                                    case "int":
                                        cell.SetCellType(CellType.NUMERIC);
                                        cell.SetCellValue(reader.GetInt32(i));
                                        break;
                                    case "datetime":

                                        cell.SetCellType(CellType.STRING);
                                        ICellStyle cellStyle = wk.CreateCellStyle();
                                        IDataFormat dataFormat = wk.CreateDataFormat();
                                        cellStyle.DataFormat = dataFormat.GetFormat("yyyy-MM-dd hh:mm:ss");
                                        cell.CellStyle = cellStyle;
                                        cell.SetCellValue(reader.GetDateTime(i));
                                        break;
                                }
                            }
                        }
                        num++;
                    }
                    using (FileStream fileStreamWrite = File.OpenWrite("24KK.xls"))
                    {
                        wk.Write(fileStreamWrite);
                    }
                }
            }
            MessageBox.Show("Test");
        }
    }
}
