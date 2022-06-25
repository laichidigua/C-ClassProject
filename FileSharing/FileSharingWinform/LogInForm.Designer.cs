namespace FileSharingWinform
{
    partial class LogInForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.TextBox_userID = new System.Windows.Forms.TextBox();
            this.TextBox_password = new System.Windows.Forms.TextBox();
            this.linkLabel_register = new System.Windows.Forms.LinkLabel();
            this.btn_login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(311, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "FileSharing";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "请输入用户名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "请输入密码：";
            // 
            // TextBox_userID
            // 
            this.TextBox_userID.Location = new System.Drawing.Point(269, 102);
            this.TextBox_userID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBox_userID.Name = "TextBox_userID";
            this.TextBox_userID.Size = new System.Drawing.Size(193, 25);
            this.TextBox_userID.TabIndex = 3;
            // 
            // TextBox_password
            // 
            this.TextBox_password.Location = new System.Drawing.Point(269, 178);
            this.TextBox_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBox_password.Name = "TextBox_password";
            this.TextBox_password.PasswordChar = '*';
            this.TextBox_password.Size = new System.Drawing.Size(193, 25);
            this.TextBox_password.TabIndex = 4;
            // 
            // linkLabel_register
            // 
            this.linkLabel_register.AutoSize = true;
            this.linkLabel_register.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel_register.Location = new System.Drawing.Point(437, 264);
            this.linkLabel_register.Name = "linkLabel_register";
            this.linkLabel_register.Size = new System.Drawing.Size(44, 18);
            this.linkLabel_register.TabIndex = 5;
            this.linkLabel_register.TabStop = true;
            this.linkLabel_register.Text = "注册";
            this.linkLabel_register.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btn_login
            // 
            this.btn_login.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_login.Location = new System.Drawing.Point(315, 258);
            this.btn_login.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(83, 32);
            this.btn_login.TabIndex = 6;
            this.btn_login.Text = "登录";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.button1_Click);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.linkLabel_register);
            this.Controls.Add(this.TextBox_password);
            this.Controls.Add(this.TextBox_userID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LogInForm";
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBox_userID;
        private System.Windows.Forms.TextBox TextBox_password;
        private System.Windows.Forms.LinkLabel linkLabel_register;
        private System.Windows.Forms.Button btn_login;
    }
}