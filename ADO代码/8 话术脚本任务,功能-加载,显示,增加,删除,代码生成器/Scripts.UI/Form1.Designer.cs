namespace Scripts.UI
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.增加一级节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增加子节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除选中节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTextSearch = new System.Windows.Forms.ToolStripTextBox();
            this.搜索ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增加一级节点ToolStripMenuItem,
            this.增加子节点ToolStripMenuItem,
            this.删除选中节点ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.tsTextSearch,
            this.搜索ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(694, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 增加一级节点ToolStripMenuItem
            // 
            this.增加一级节点ToolStripMenuItem.Name = "增加一级节点ToolStripMenuItem";
            this.增加一级节点ToolStripMenuItem.Size = new System.Drawing.Size(89, 21);
            this.增加一级节点ToolStripMenuItem.Text = "增加一级节点";
            this.增加一级节点ToolStripMenuItem.Click += new System.EventHandler(this.增加一级节点ToolStripMenuItem_Click);
            // 
            // 增加子节点ToolStripMenuItem
            // 
            this.增加子节点ToolStripMenuItem.Name = "增加子节点ToolStripMenuItem";
            this.增加子节点ToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.增加子节点ToolStripMenuItem.Text = "增加子节点";
            this.增加子节点ToolStripMenuItem.Click += new System.EventHandler(this.增加子节点ToolStripMenuItem_Click);
            // 
            // 删除选中节点ToolStripMenuItem
            // 
            this.删除选中节点ToolStripMenuItem.Name = "删除选中节点ToolStripMenuItem";
            this.删除选中节点ToolStripMenuItem.Size = new System.Drawing.Size(89, 21);
            this.删除选中节点ToolStripMenuItem.Text = "删除选中节点";
            this.删除选中节点ToolStripMenuItem.Click += new System.EventHandler(this.删除选中节点ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(89, 21);
            this.toolStripMenuItem1.Text = "编辑修改节点";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tsTextSearch
            // 
            this.tsTextSearch.Name = "tsTextSearch";
            this.tsTextSearch.Size = new System.Drawing.Size(121, 21);
            // 
            // 搜索ToolStripMenuItem
            // 
            this.搜索ToolStripMenuItem.Name = "搜索ToolStripMenuItem";
            this.搜索ToolStripMenuItem.Size = new System.Drawing.Size(41, 21);
            this.搜索ToolStripMenuItem.Text = "搜索";
            this.搜索ToolStripMenuItem.Click += new System.EventHandler(this.搜索ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Size = new System.Drawing.Size(694, 499);
            this.splitContainer1.SplitterDistance = 230;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(230, 499);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(460, 499);
            this.textBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 524);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 增加一级节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增加子节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除选中节点ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripTextBox tsTextSearch;
        private System.Windows.Forms.ToolStripMenuItem 搜索ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

