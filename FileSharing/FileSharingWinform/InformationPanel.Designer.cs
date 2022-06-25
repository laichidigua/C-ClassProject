namespace FileSharingWinform
{
    partial class InformationPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_filename = new System.Windows.Forms.Label();
            this.label_username = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_description = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 46);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(116, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件信息";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Controls.Add(this.label_filename);
            this.panel2.Controls.Add(this.label_username);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 46);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 326);
            this.panel2.TabIndex = 1;
            // 
            // label_filename
            // 
            this.label_filename.AutoSize = true;
            this.label_filename.Location = new System.Drawing.Point(125, 48);
            this.label_filename.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_filename.Name = "label_filename";
            this.label_filename.Size = new System.Drawing.Size(41, 12);
            this.label_filename.TabIndex = 4;
            this.label_filename.Text = "label6";
            this.label_filename.Click += new System.EventHandler(this.label_filename_Click);
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Location = new System.Drawing.Point(125, 11);
            this.label_username.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(41, 12);
            this.label_username.TabIndex = 3;
            this.label_username.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "文件描述信息：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "文件名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "用户名：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label_description);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 214);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(361, 158);
            this.panel3.TabIndex = 2;
            // 
            // label_description
            // 
            this.label_description.BackColor = System.Drawing.SystemColors.Info;
            this.label_description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_description.Location = new System.Drawing.Point(0, 0);
            this.label_description.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(361, 158);
            this.label_description.TabIndex = 0;
            this.label_description.Text = "label7";
            // 
            // InformationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "InformationPanel";
            this.Size = new System.Drawing.Size(361, 372);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_filename;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label_description;
    }
}
