namespace StoneZizzorsCloth
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblUserInput = new System.Windows.Forms.Label();
            this.lblComputerInput = new System.Windows.Forms.Label();
            this.bntStone = new System.Windows.Forms.Button();
            this.btnZizzors = new System.Windows.Forms.Button();
            this.btnCloth = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "玩家:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(341, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "电脑:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(260, 119);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 25);
            this.lblResult.TabIndex = 2;
            // 
            // lblUserInput
            // 
            this.lblUserInput.AutoSize = true;
            this.lblUserInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInput.Location = new System.Drawing.Point(154, 67);
            this.lblUserInput.Name = "lblUserInput";
            this.lblUserInput.Size = new System.Drawing.Size(0, 25);
            this.lblUserInput.TabIndex = 3;
            // 
            // lblComputerInput
            // 
            this.lblComputerInput.AutoSize = true;
            this.lblComputerInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComputerInput.Location = new System.Drawing.Point(414, 66);
            this.lblComputerInput.Name = "lblComputerInput";
            this.lblComputerInput.Size = new System.Drawing.Size(0, 25);
            this.lblComputerInput.TabIndex = 3;
            // 
            // bntStone
            // 
            this.bntStone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntStone.Location = new System.Drawing.Point(114, 184);
            this.bntStone.Name = "bntStone";
            this.bntStone.Size = new System.Drawing.Size(74, 39);
            this.bntStone.TabIndex = 4;
            this.bntStone.Text = "石头";
            this.bntStone.UseVisualStyleBackColor = true;
            this.bntStone.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnZizzors
            // 
            this.btnZizzors.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZizzors.Location = new System.Drawing.Point(220, 184);
            this.btnZizzors.Name = "btnZizzors";
            this.btnZizzors.Size = new System.Drawing.Size(74, 39);
            this.btnZizzors.TabIndex = 4;
            this.btnZizzors.Text = "剪刀";
            this.btnZizzors.UseVisualStyleBackColor = true;
            this.btnZizzors.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCloth
            // 
            this.btnCloth.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloth.Location = new System.Drawing.Point(328, 184);
            this.btnCloth.Name = "btnCloth";
            this.btnCloth.Size = new System.Drawing.Size(74, 39);
            this.btnCloth.TabIndex = 4;
            this.btnCloth.Text = "布";
            this.btnCloth.UseVisualStyleBackColor = true;
            this.btnCloth.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 262);
            this.Controls.Add(this.btnCloth);
            this.Controls.Add(this.btnZizzors);
            this.Controls.Add(this.bntStone);
            this.Controls.Add(this.lblComputerInput);
            this.Controls.Add(this.lblUserInput);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblUserInput;
        private System.Windows.Forms.Label lblComputerInput;
        private System.Windows.Forms.Button bntStone;
        private System.Windows.Forms.Button btnZizzors;
        private System.Windows.Forms.Button btnCloth;
    }
}

