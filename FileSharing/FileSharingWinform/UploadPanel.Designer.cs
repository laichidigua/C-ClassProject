namespace FileSharingWinform
{
    partial class UploadPanel
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
            this.btn_confirminfo = new System.Windows.Forms.Button();
            this.txBox_subject = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txBox_discrip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkBox_private = new System.Windows.Forms.CheckBox();
            this.btn_chosefile = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(302, 45);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件上传信息";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Controls.Add(this.label_filename);
            this.panel2.Controls.Add(this.btn_confirminfo);
            this.panel2.Controls.Add(this.txBox_subject);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txBox_discrip);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.chkBox_private);
            this.panel2.Controls.Add(this.btn_chosefile);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(302, 305);
            this.panel2.TabIndex = 1;
            // 
            // label_filename
            // 
            this.label_filename.AutoSize = true;
            this.label_filename.Location = new System.Drawing.Point(106, 22);
            this.label_filename.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_filename.Name = "label_filename";
            this.label_filename.Size = new System.Drawing.Size(0, 12);
            this.label_filename.TabIndex = 7;
            // 
            // btn_confirminfo
            // 
            this.btn_confirminfo.Location = new System.Drawing.Point(91, 219);
            this.btn_confirminfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_confirminfo.Name = "btn_confirminfo";
            this.btn_confirminfo.Size = new System.Drawing.Size(56, 24);
            this.btn_confirminfo.TabIndex = 6;
            this.btn_confirminfo.Text = "确认";
            this.btn_confirminfo.UseVisualStyleBackColor = true;
            this.btn_confirminfo.Click += new System.EventHandler(this.btn_confirminfo_Click);
            // 
            // txBox_subject
            // 
            this.txBox_subject.Location = new System.Drawing.Point(61, 182);
            this.txBox_subject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txBox_subject.Name = "txBox_subject";
            this.txBox_subject.Size = new System.Drawing.Size(112, 21);
            this.txBox_subject.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 184);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "主题：";
            // 
            // txBox_discrip
            // 
            this.txBox_discrip.Location = new System.Drawing.Point(28, 71);
            this.txBox_discrip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txBox_discrip.Multiline = true;
            this.txBox_discrip.Name = "txBox_discrip";
            this.txBox_discrip.Size = new System.Drawing.Size(213, 94);
            this.txBox_discrip.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "请输入文件描述：";
            // 
            // chkBox_private
            // 
            this.chkBox_private.AutoSize = true;
            this.chkBox_private.Location = new System.Drawing.Point(196, 184);
            this.chkBox_private.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkBox_private.Name = "chkBox_private";
            this.chkBox_private.Size = new System.Drawing.Size(48, 16);
            this.chkBox_private.TabIndex = 1;
            this.chkBox_private.Text = "私有";
            this.chkBox_private.UseVisualStyleBackColor = true;
            // 
            // btn_chosefile
            // 
            this.btn_chosefile.Location = new System.Drawing.Point(10, 13);
            this.btn_chosefile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_chosefile.Name = "btn_chosefile";
            this.btn_chosefile.Size = new System.Drawing.Size(74, 29);
            this.btn_chosefile.TabIndex = 0;
            this.btn_chosefile.Text = "选择文件";
            this.btn_chosefile.UseVisualStyleBackColor = true;
            this.btn_chosefile.Click += new System.EventHandler(this.btn_chosefile_Click);
            // 
            // UploadPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UploadPanel";
            this.Size = new System.Drawing.Size(302, 350);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txBox_discrip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkBox_private;
        private System.Windows.Forms.Button btn_chosefile;
        private System.Windows.Forms.TextBox txBox_subject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_confirminfo;
        private System.Windows.Forms.Label label_filename;
    }
}
