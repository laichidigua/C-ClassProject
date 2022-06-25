namespace FileSharingWinform
{
    partial class RegisterForm
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
            this.btn_confirm = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "请设置用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "请设置密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(356, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "注册";
            // 
            // TextBox_userID
            // 
            this.TextBox_userID.Location = new System.Drawing.Point(259, 115);
            this.TextBox_userID.Name = "TextBox_userID";
            this.TextBox_userID.Size = new System.Drawing.Size(237, 25);
            this.TextBox_userID.TabIndex = 3;
            // 
            // TextBox_password
            // 
            this.TextBox_password.Location = new System.Drawing.Point(259, 182);
            this.TextBox_password.Name = "TextBox_password";
            this.TextBox_password.Size = new System.Drawing.Size(237, 25);
            this.TextBox_password.TabIndex = 4;
            // 
            // btn_confirm
            // 
            this.btn_confirm.BackColor = System.Drawing.SystemColors.Menu;
            this.btn_confirm.Location = new System.Drawing.Point(299, 279);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(69, 35);
            this.btn_confirm.TabIndex = 5;
            this.btn_confirm.Text = "确定";
            this.btn_confirm.UseVisualStyleBackColor = false;
            this.btn_confirm.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(403, 279);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(76, 35);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.TextBox_password);
            this.Controls.Add(this.TextBox_userID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBox_userID;
        private System.Windows.Forms.TextBox TextBox_password;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Button btn_cancel;
    }
}