namespace Stu.UI
{
    partial class frmStudent
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.datepickerBirthdayAdd = new System.Windows.Forms.DateTimePicker();
            this.cboClassAdd = new System.Windows.Forms.ComboBox();
            this.cboGenderAdd = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboAgeAdd = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEnglishAdd = new System.Windows.Forms.TextBox();
            this.txtMathAdd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNameAdd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtNameSearch = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboClassSearch = new System.Windows.Forms.ComboBox();
            this.cboGenderSearch = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblAutoId = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.datepickerBirthdayEdit = new System.Windows.Forms.DateTimePicker();
            this.cboClassEdit = new System.Windows.Forms.ComboBox();
            this.cboGenderEdit = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboAgeEdit = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEnglishEdit = new System.Windows.Forms.TextBox();
            this.txtMathEdit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNameEdit = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.datepickerBirthdayAdd);
            this.groupBox1.Controls.Add(this.cboClassAdd);
            this.groupBox1.Controls.Add(this.cboGenderAdd);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboAgeAdd);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEnglishAdd);
            this.groupBox1.Controls.Add(this.txtMathAdd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNameAdd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblAge);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "add new student";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(590, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "增加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // datepickerBirthdayAdd
            // 
            this.datepickerBirthdayAdd.Location = new System.Drawing.Point(465, 64);
            this.datepickerBirthdayAdd.Name = "datepickerBirthdayAdd";
            this.datepickerBirthdayAdd.Size = new System.Drawing.Size(200, 21);
            this.datepickerBirthdayAdd.TabIndex = 3;
            // 
            // cboClassAdd
            // 
            this.cboClassAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClassAdd.FormattingEnabled = true;
            this.cboClassAdd.Location = new System.Drawing.Point(520, 28);
            this.cboClassAdd.Name = "cboClassAdd";
            this.cboClassAdd.Size = new System.Drawing.Size(147, 20);
            this.cboClassAdd.TabIndex = 2;
            // 
            // cboGenderAdd
            // 
            this.cboGenderAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGenderAdd.FormattingEnabled = true;
            this.cboGenderAdd.Location = new System.Drawing.Point(389, 28);
            this.cboGenderAdd.Name = "cboGenderAdd";
            this.cboGenderAdd.Size = new System.Drawing.Size(59, 20);
            this.cboGenderAdd.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(473, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Class";
            // 
            // cboAgeAdd
            // 
            this.cboAgeAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgeAdd.FormattingEnabled = true;
            this.cboAgeAdd.Location = new System.Drawing.Point(247, 28);
            this.cboAgeAdd.Name = "cboAgeAdd";
            this.cboAgeAdd.Size = new System.Drawing.Size(59, 20);
            this.cboAgeAdd.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(402, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "Birthday";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Gender";
            // 
            // txtEnglishAdd
            // 
            this.txtEnglishAdd.Location = new System.Drawing.Point(247, 64);
            this.txtEnglishAdd.Name = "txtEnglishAdd";
            this.txtEnglishAdd.Size = new System.Drawing.Size(100, 21);
            this.txtEnglishAdd.TabIndex = 1;
            // 
            // txtMathAdd
            // 
            this.txtMathAdd.Location = new System.Drawing.Point(74, 65);
            this.txtMathAdd.Name = "txtMathAdd";
            this.txtMathAdd.Size = new System.Drawing.Size(100, 21);
            this.txtMathAdd.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "English";
            // 
            // txtNameAdd
            // 
            this.txtNameAdd.Location = new System.Drawing.Point(74, 28);
            this.txtNameAdd.Name = "txtNameAdd";
            this.txtNameAdd.Size = new System.Drawing.Size(100, 21);
            this.txtNameAdd.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Math";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(200, 31);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(23, 12);
            this.lblAge.TabIndex = 0;
            this.lblAge.Text = "Age";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridView1.Location = new System.Drawing.Point(27, 147);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(705, 316);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Fid";
            this.Column1.HeaderText = "编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "FName";
            this.Column2.HeaderText = "姓名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Fage";
            this.Column3.HeaderText = "年龄";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Fgender";
            this.Column4.HeaderText = "性别";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "FMath";
            this.Column5.HeaderText = "数学成绩";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "FEnglish";
            this.Column6.HeaderText = "英语成绩";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Class";
            this.Column7.HeaderText = "所在班级";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "FBirthday";
            this.Column8.HeaderText = "出生日期";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(590, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(490, 95);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "保存修改";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblResult);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.txtNameSearch);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.cboClassSearch);
            this.groupBox3.Controls.Add(this.cboGenderSearch);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Location = new System.Drawing.Point(743, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(237, 216);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search student";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(24, 140);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "显示查询结果";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtNameSearch
            // 
            this.txtNameSearch.Location = new System.Drawing.Point(69, 41);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(147, 21);
            this.txtNameSearch.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 44);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "Name";
            // 
            // cboClassSearch
            // 
            this.cboClassSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClassSearch.FormattingEnabled = true;
            this.cboClassSearch.Location = new System.Drawing.Point(69, 72);
            this.cboClassSearch.Name = "cboClassSearch";
            this.cboClassSearch.Size = new System.Drawing.Size(147, 20);
            this.cboClassSearch.TabIndex = 2;
            // 
            // cboGenderSearch
            // 
            this.cboGenderSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGenderSearch.FormattingEnabled = true;
            this.cboGenderSearch.Location = new System.Drawing.Point(69, 106);
            this.cboGenderSearch.Name = "cboGenderSearch";
            this.cboGenderSearch.Size = new System.Drawing.Size(74, 20);
            this.cboGenderSearch.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(22, 75);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "Class";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(22, 109);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "Gender";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblAutoId);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.datepickerBirthdayEdit);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.cboClassEdit);
            this.groupBox2.Controls.Add(this.cboGenderEdit);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboAgeEdit);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtEnglishEdit);
            this.groupBox2.Controls.Add(this.txtMathEdit);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtNameEdit);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(27, 469);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(705, 124);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "edit student";
            // 
            // lblAutoId
            // 
            this.lblAutoId.AutoSize = true;
            this.lblAutoId.Location = new System.Drawing.Point(56, 31);
            this.lblAutoId.Name = "lblAutoId";
            this.lblAutoId.Size = new System.Drawing.Size(17, 12);
            this.lblAutoId.TabIndex = 5;
            this.lblAutoId.Text = "Id";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(30, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 12);
            this.label14.TabIndex = 5;
            this.label14.Text = "Id:";
            // 
            // datepickerBirthdayEdit
            // 
            this.datepickerBirthdayEdit.Location = new System.Drawing.Point(465, 64);
            this.datepickerBirthdayEdit.Name = "datepickerBirthdayEdit";
            this.datepickerBirthdayEdit.Size = new System.Drawing.Size(200, 21);
            this.datepickerBirthdayEdit.TabIndex = 3;
            // 
            // cboClassEdit
            // 
            this.cboClassEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClassEdit.FormattingEnabled = true;
            this.cboClassEdit.Location = new System.Drawing.Point(520, 28);
            this.cboClassEdit.Name = "cboClassEdit";
            this.cboClassEdit.Size = new System.Drawing.Size(147, 20);
            this.cboClassEdit.TabIndex = 2;
            // 
            // cboGenderEdit
            // 
            this.cboGenderEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGenderEdit.FormattingEnabled = true;
            this.cboGenderEdit.Location = new System.Drawing.Point(404, 28);
            this.cboGenderEdit.Name = "cboGenderEdit";
            this.cboGenderEdit.Size = new System.Drawing.Size(59, 20);
            this.cboGenderEdit.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Class";
            // 
            // cboAgeEdit
            // 
            this.cboAgeEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgeEdit.FormattingEnabled = true;
            this.cboAgeEdit.Location = new System.Drawing.Point(289, 28);
            this.cboAgeEdit.Name = "cboAgeEdit";
            this.cboAgeEdit.Size = new System.Drawing.Size(59, 20);
            this.cboAgeEdit.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(402, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "Birthday";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(360, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "Gender";
            // 
            // txtEnglishEdit
            // 
            this.txtEnglishEdit.Location = new System.Drawing.Point(247, 64);
            this.txtEnglishEdit.Name = "txtEnglishEdit";
            this.txtEnglishEdit.Size = new System.Drawing.Size(100, 21);
            this.txtEnglishEdit.TabIndex = 1;
            // 
            // txtMathEdit
            // 
            this.txtMathEdit.Location = new System.Drawing.Point(74, 65);
            this.txtMathEdit.Name = "txtMathEdit";
            this.txtMathEdit.Size = new System.Drawing.Size(100, 21);
            this.txtMathEdit.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(200, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "English";
            // 
            // txtNameEdit
            // 
            this.txtNameEdit.Location = new System.Drawing.Point(155, 28);
            this.txtNameEdit.Name = "txtNameEdit";
            this.txtNameEdit.Size = new System.Drawing.Size(100, 21);
            this.txtNameEdit.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "Math";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(260, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "Age";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(115, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "Name";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(22, 182);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(47, 12);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "label18";
            // 
            // frmStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 601);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmStudent";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmStudent_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker datepickerBirthdayAdd;
        private System.Windows.Forms.ComboBox cboClassAdd;
        private System.Windows.Forms.ComboBox cboGenderAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboAgeAdd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEnglishAdd;
        private System.Windows.Forms.TextBox txtMathAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNameAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtNameSearch;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboClassSearch;
        private System.Windows.Forms.ComboBox cboGenderSearch;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker datepickerBirthdayEdit;
        private System.Windows.Forms.ComboBox cboClassEdit;
        private System.Windows.Forms.ComboBox cboGenderEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboAgeEdit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEnglishEdit;
        private System.Windows.Forms.TextBox txtMathEdit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNameEdit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblAutoId;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Label lblResult;
    }
}

