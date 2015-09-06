using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RenYuan.Model;
using RenYuan.BLL;

namespace RenYuan.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboGender.SelectedIndex = 0;
            LoadData();
        }

        private void LoadData()
        {
            //把数据显示到DataGridView中
            TblPersonBll bll = new TblPersonBll();
            dataGridView1.DataSource = bll.GetAllData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1.采集用户的输入
            TblPerson model = new TblPerson();
            model.Name = txtName.Text.Trim();
            model.Age = int.Parse(txtAge.Text.Trim());
            model.Height = txtHeight.Text.Trim().Length == 0 ? null : (int?)int.Parse(txtHeight.Text.Trim());
            model.Gender = cboGender.SelectedIndex == 0 ? true : false;

            TblPersonBll bll = new TblPersonBll();
            int r = bll.Add(model);
            MessageBox.Show("成功插入了" + r + "条记录！");
        }


        //当焦点进入当前行的事件
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //获取当前行的信息
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            lblAutoId.Text = row.Cells[0].Value.ToString();
            txtNameEdit.Text = row.Cells[1].Value.ToString();
            txtAgeEdit.Text = row.Cells[2].Value.ToString();
            txtHeightEdit.Text = row.Cells[3].Value == null ? string.Empty : row.Cells[3].Value.ToString();
            cboGenderEdit.SelectedIndex = (row.Cells[4].Value == null || row.Cells[4].Value.ToString().ToLower() == "true") ? 0 : 1;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            TblPersonBll bll = new TblPersonBll();
            int r = bll.DeleteByAutoId(int.Parse(lblAutoId.Text));
            MessageBox.Show("成功删除了" + r + "行。");
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1.采集用户的输入
            TblPerson model = new TblPerson();
            model.AutoId = int.Parse(lblAutoId.Text.Trim());
            model.Name = txtNameEdit.Text.Trim();
            model.Age = int.Parse(txtAgeEdit.Text.Trim());
            model.Height = txtHeightEdit.Text.Trim().Length == 0 ? null : (int?)int.Parse(txtHeightEdit.Text.Trim());
            model.Gender = cboGenderEdit.SelectedIndex == 0 ? true : false;
            //2.调用业务逻辑层实现更新
            TblPersonBll bll = new TblPersonBll();
            int r = bll.UpdateByAutoId(model);
            MessageBox.Show("成功更新了" + r + "行。");
            LoadData();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is bool && e.ColumnIndex == 4 && e.Value != null)
            {
                if ((bool)e.Value)
                {
                    e.Value = "男";
                }
                else
                {
                    e.Value = "女";
                }
            }
        }
    }
}
