namespace Scripts.UI
{
    partial class frmGenericCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtConStr = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lboxTables = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNs = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // txtConStr
            // 
            this.txtConStr.Location = new System.Drawing.Point(59, 21);
            this.txtConStr.Name = "txtConStr";
            this.txtConStr.Size = new System.Drawing.Size(714, 21);
            this.txtConStr.TabIndex = 1;
            this.txtConStr.Text = "Data Source=steve-pc;Initial Catalog=CCDB;Integrated Security=True";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "连接";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lboxTables
            // 
            this.lboxTables.FormattingEnabled = true;
            this.lboxTables.ItemHeight = 12;
            this.lboxTables.Location = new System.Drawing.Point(12, 105);
            this.lboxTables.Name = "lboxTables";
            this.lboxTables.Size = new System.Drawing.Size(133, 328);
            this.lboxTables.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "命名空间";
            // 
            // txtNs
            // 
            this.txtNs.Location = new System.Drawing.Point(164, 48);
            this.txtNs.Name = "txtNs";
            this.txtNs.Size = new System.Drawing.Size(609, 21);
            this.txtNs.TabIndex = 4;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(164, 105);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCode.Size = new System.Drawing.Size(609, 324);
            this.txtCode.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(164, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "生成代码";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmGenericCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 444);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtNs);
            this.Controls.Add(this.lboxTables);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtConStr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmGenericCode";
            this.Text = "frmGenericCode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConStr;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lboxTables;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNs;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button button2;
    }
}