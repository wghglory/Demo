using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _02省市联动
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            //加载省份信息到第一个ComboBox
            LoadProvince();

            //设置两个下拉菜单的默认值为“请选择”
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

        }
        private void LoadProvince()
        {

            string sql = "select * from TblArea where AreaPid=0";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProvinceItem item = new ProvinceItem();
                        item.AreaId = reader.GetInt32(0);
                        item.AreaName = reader.GetString(1);
                        item.AreaPid = reader.GetInt32(2);
                        comboBox1.Items.Add(item);
                    }
                }
            }
            //为ComboBox 增加一个“请选择”
            ProvinceItem itemDefault = new ProvinceItem();
            itemDefault.AreaId = -1;
            itemDefault.AreaName = "请选择";
            comboBox1.Items.Insert(0, itemDefault);

        }

        //下拉菜单的选择项改变事件
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取当前用户选择的项
            if (comboBox1.SelectedIndex > 0)
            {
                //加载第二个下拉菜单，数据来源：根据第一个下拉菜单用户选择项的AreaId来查询该项的所有子项。(子项：指的就是当前选中省份的下的直接城市)

                //获取当前选中项的id
                ProvinceItem item = comboBox1.SelectedItem as ProvinceItem;
                int areaId = item.AreaId;
                LoadCity(areaId);
            }
        }

        private void LoadCity(int areaId)
        {
            comboBox2.Items.Clear();
            string sql = "select * from TblArea where areaPId=@aid";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@aid", areaId)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProvinceItem item = new ProvinceItem();
                        item.AreaId = reader.GetInt32(0);
                        item.AreaName = reader.GetString(1);
                        item.AreaPid = reader.GetInt32(2);
                        comboBox2.Items.Add(item);
                    }
                }
            }

            //也加一个【请选择】
            ProvinceItem itemDefault = new ProvinceItem();
            itemDefault.AreaId = -1;
            itemDefault.AreaName = "请选择";
            comboBox2.Items.Insert(0, itemDefault);
            comboBox2.SelectedIndex = 0;
        }
    }
}
