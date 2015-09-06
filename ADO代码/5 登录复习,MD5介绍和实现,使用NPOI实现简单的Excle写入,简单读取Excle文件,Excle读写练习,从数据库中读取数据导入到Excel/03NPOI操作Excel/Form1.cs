using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;

namespace _03NPOI操作Excel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //Excel写入
        private void button1_Click(object sender, EventArgs e)
        {
            //1.在内存中创建一个Excel对象
            //Excel就是一个Workbook,其实就是创建一个Workbook对象
            using (Workbook wk = new HSSFWorkbook())
            {
                //在workbook中创建一个Sheet
                using (Sheet sheet = wk.CreateSheet("工作表1"))
                {
                    //向当前的Sheet中创建一些行
                    for (int i = 0; i < 10; i++)
                    {
                        //在当前Sheet中创建一行
                        Row row = sheet.CreateRow(i);
                        //向当前行中添加两个单元格
                        //创建一个单元格
                        Cell c1 = row.CreateCell(0);
                        //设置当前单元格显示的内容
                        c1.SetCellValue(i);

                        Cell c2 = row.CreateCell(1);
                        c2.SetCellValue(i.ToString());

                    }

                    //1.创建一个文件流
                    using (FileStream fs = File.OpenWrite("test.xls"))
                    {
                        ////当所有行都创建完毕后就把当前的Excel对象保存到磁盘上
                        wk.Write(fs);
                    }
                }
            }
            MessageBox.Show("创建Excel成功！");

        }


        //读取Excel文件
        private void button2_Click(object sender, EventArgs e)
        {
            using (FileStream fs = File.OpenRead("ReadExcel.xls"))
            {
                //读取指定的Excel文件，把文件的内容读出到控制台上
                //1.创建一个Workbook对象（根据指定的文件流fs,创建一个Workbook对象，会自动把指定的Excel加载到该Workbook对象中）
                using (Workbook wk = new HSSFWorkbook(fs))
                {
                    //遍历当前Workbook中的每个Sheet
                    //wk.NumberOfSheets,获取当前工作薄中的工作表的个数。
                    //遍历访问每个工作表
                    for (int i = 0; i < wk.NumberOfSheets; i++)
                    {
                        //获取每一个工作表
                        using (Sheet sheet = wk.GetSheetAt(i))
                        {
                            Console.WriteLine("工作表名称：  " + sheet.SheetName);
                            //获取当前工作表下的所有行
                            //获取当前工作表下的所有的行
                            //循环每一样
                            for (int r = 0; r <= sheet.LastRowNum; r++)
                            {
                                //获取当前行
                                Row row = sheet.GetRow(r);

                                //获取当前行中的每个单元格
                                //循环遍历每个单元格
                                for (int c = 0; c < row.LastCellNum; c++)
                                {
                                    //获取每个单元格
                                    Cell cell = row.GetCell(c);
                                    if (cell != null)
                                    {
                                        //获取单元格中的内容
                                        Console.Write(cell.ToString());
                                        //cell.StringCellValue
                                    }

                                }
                                Console.WriteLine();
                            }

                        }
                    }
                }
            }



            //2.读取当前Workbook的每个Sheet

            //3.读取每个Sheet中的Row（行）


            //4.读取行中的每个单元格
        }

        //Excel写入
        private void button3_Click(object sender, EventArgs e)
        {
            //创建一个Workbook
            using (Workbook wk = new HSSFWorkbook())
            {
                //创建一个Sheet
                using (Sheet sheet = wk.CreateSheet("个人信息"))
                {
                    //创建一行
                    Row row = sheet.CreateRow(0);
                    //为该行创建单元格Cell
                    row.CreateCell(0).SetCellValue("张三");

                    row.CreateCell(1).SetCellValue("男");
                    row.CreateCell(2).SetCellValue(18);
                    Cell cellDateTime = row.CreateCell(3);
                    cellDateTime.SetCellValue(System.DateTime.Now);

                    CellStyle cellStyle = wk.CreateCellStyle();
                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("m/d/yy h:mm");
                    cellDateTime.CellStyle = cellStyle;



                    using (FileStream fs = File.OpenWrite("myinfo.xls"))
                    {
                        wk.Write(fs);
                    }
                }

            }
            MessageBox.Show("ok");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (FileStream fsReader = File.OpenRead("myinfo.xls"))
            {
                //读取个人信息Excel
                using (Workbook wk = new HSSFWorkbook(fsReader))
                {
                    using (Sheet sheet = wk.GetSheetAt(0))
                    {
                        Row row = sheet.GetRow(0);
                        Console.WriteLine("姓名：{0}，年龄：{1}，性别：{2},日期：{3}", row.GetCell(0).StringCellValue, row.GetCell(2).NumericCellValue, row.GetCell(1).StringCellValue, row.GetCell(3).DateCellValue);
                    }
                }
            }

        }
    }
}
