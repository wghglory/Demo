namespace _08三连击触发事件
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.userControlButton1 = new _08三连击触发事件.UserControlDelegateButton();
            this.userControlEvent1 = new _08三连击触发事件.UserControlEvent();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // userControlButton1
            // 
            this.userControlButton1.Location = new System.Drawing.Point(62, 158);
            this.userControlButton1.Name = "userControlButton1";
            this.userControlButton1.Size = new System.Drawing.Size(124, 44);
            this.userControlButton1.TabIndex = 1;

            // 
            // userControlEvent1
            // 
            this.userControlEvent1.Location = new System.Drawing.Point(43, 21);
            this.userControlEvent1.Name = "userControlEvent1";
            this.userControlEvent1.Size = new System.Drawing.Size(125, 56);
            this.userControlEvent1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.userControlEvent1);
            this.Controls.Add(this.userControlButton1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private UserControlDelegateButton userControlButton1;
        private UserControlEvent userControlEvent1;
    }
}

