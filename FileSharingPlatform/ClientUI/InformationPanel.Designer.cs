namespace ClientUI
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
            this.description = new System.Windows.Forms.Label();
            this.clientName = new System.Windows.Forms.Label();
            this.filename = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.description);
            this.panel1.Controls.Add(this.clientName);
            this.panel1.Controls.Add(this.filename);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 302);
            this.panel1.TabIndex = 0;
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(44, 135);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(69, 20);
            this.description.TabIndex = 3;
            this.description.Text = "文件描述";
            // 
            // clientName
            // 
            this.clientName.AutoSize = true;
            this.clientName.Location = new System.Drawing.Point(44, 49);
            this.clientName.Name = "clientName";
            this.clientName.Size = new System.Drawing.Size(54, 20);
            this.clientName.TabIndex = 2;
            this.clientName.Text = "用户名";
            // 
            // filename
            // 
            this.filename.AutoSize = true;
            this.filename.Location = new System.Drawing.Point(44, 82);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(54, 20);
            this.filename.TabIndex = 1;
            this.filename.Text = "文件名";
            // 
            // InformationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "InformationPanel";
            this.Size = new System.Drawing.Size(310, 302);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label filename;
        private Label clientName;
        private Label description;
    }
}
