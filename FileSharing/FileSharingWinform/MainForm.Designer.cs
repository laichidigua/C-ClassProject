namespace FileSharingWinform
{
    partial class MainForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_keyword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_download = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tree_file = new System.Windows.Forms.TreeView();
            this.FileInfoPanel = new System.Windows.Forms.Panel();
            this.btn_upload = new System.Windows.Forms.Button();
            this.btn_creatfile = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.375F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.625F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.FileInfoPanel, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.88889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.textBox_keyword);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 52);
            this.panel1.TabIndex = 0;
            // 
            // textBox_keyword
            // 
            this.textBox_keyword.Location = new System.Drawing.Point(121, 13);
            this.textBox_keyword.Multiline = true;
            this.textBox_keyword.Name = "textBox_keyword";
            this.textBox_keyword.Size = new System.Drawing.Size(217, 25);
            this.textBox_keyword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入关键词：";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(355, 8);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 30);
            this.btn_search.TabIndex = 0;
            this.btn_search.Text = "搜索";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.btn_delete);
            this.panel2.Controls.Add(this.btn_creatfile);
            this.panel2.Controls.Add(this.btn_download);
            this.panel2.Controls.Add(this.btn_upload);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(454, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(343, 52);
            this.panel2.TabIndex = 1;
            // 
            // btn_download
            // 
            this.btn_download.Location = new System.Drawing.Point(265, 8);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(75, 30);
            this.btn_download.TabIndex = 2;
            this.btn_download.Text = "下载";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tree_file);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(445, 386);
            this.panel3.TabIndex = 2;
            // 
            // tree_file
            // 
            this.tree_file.BackColor = System.Drawing.SystemColors.Info;
            this.tree_file.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_file.Location = new System.Drawing.Point(0, 0);
            this.tree_file.Name = "tree_file";
            this.tree_file.Size = new System.Drawing.Size(445, 386);
            this.tree_file.TabIndex = 0;
            this.tree_file.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_file_AfterSelect);
            // 
            // FileInfoPanel
            // 
            this.FileInfoPanel.BackColor = System.Drawing.SystemColors.Menu;
            this.FileInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileInfoPanel.Location = new System.Drawing.Point(454, 61);
            this.FileInfoPanel.Name = "FileInfoPanel";
            this.FileInfoPanel.Size = new System.Drawing.Size(343, 386);
            this.FileInfoPanel.TabIndex = 3;
            // 
            // btn_upload
            // 
            this.btn_upload.Location = new System.Drawing.Point(184, 8);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(75, 30);
            this.btn_upload.TabIndex = 1;
            this.btn_upload.Text = "上传";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // btn_creatfile
            // 
            this.btn_creatfile.Location = new System.Drawing.Point(3, 8);
            this.btn_creatfile.Name = "btn_creatfile";
            this.btn_creatfile.Size = new System.Drawing.Size(97, 31);
            this.btn_creatfile.TabIndex = 3;
            this.btn_creatfile.Text = "新建文件夹";
            this.btn_creatfile.UseVisualStyleBackColor = true;
            this.btn_creatfile.Click += new System.EventHandler(this.btn_creatfile_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(103, 8);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 31);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "删除";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel FileInfoPanel;
        private System.Windows.Forms.TextBox textBox_keyword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TreeView tree_file;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.Button btn_creatfile;
        private System.Windows.Forms.Button btn_delete;
    }
}