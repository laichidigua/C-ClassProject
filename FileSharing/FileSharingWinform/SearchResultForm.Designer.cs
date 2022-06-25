namespace FileSharingWinform
{
    partial class SearchResultForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_download = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FileResultVIew = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uploudTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.downloadTimesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileInfo_bds = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileResultVIew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileInfo_bds)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Controls.Add(this.btn_download);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 64);
            this.panel1.TabIndex = 0;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(652, 14);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(136, 38);
            this.btn_add.TabIndex = 1;
            this.btn_add.Text = "加入我的云盘";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_download
            // 
            this.btn_download.Location = new System.Drawing.Point(556, 14);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(73, 38);
            this.btn_download.TabIndex = 0;
            this.btn_download.Text = "下载";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.FileResultVIew);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 386);
            this.panel2.TabIndex = 1;
            // 
            // FileResultVIew
            // 
            this.FileResultVIew.AutoGenerateColumns = false;
            this.FileResultVIew.BackgroundColor = System.Drawing.SystemColors.Info;
            this.FileResultVIew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FileResultVIew.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.uploudTimeDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.subjectDataGridViewTextBoxColumn,
            this.lengthDataGridViewTextBoxColumn,
            this.downloadTimesDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.FileResultVIew.DataSource = this.FileInfo_bds;
            this.FileResultVIew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileResultVIew.Location = new System.Drawing.Point(0, 0);
            this.FileResultVIew.Name = "FileResultVIew";
            this.FileResultVIew.RowHeadersWidth = 51;
            this.FileResultVIew.RowTemplate.Height = 27;
            this.FileResultVIew.Size = new System.Drawing.Size(800, 386);
            this.FileResultVIew.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "文件名";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 75;
            // 
            // uploudTimeDataGridViewTextBoxColumn
            // 
            this.uploudTimeDataGridViewTextBoxColumn.DataPropertyName = "UploudTime";
            this.uploudTimeDataGridViewTextBoxColumn.HeaderText = "上传时间";
            this.uploudTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.uploudTimeDataGridViewTextBoxColumn.Name = "uploudTimeDataGridViewTextBoxColumn";
            this.uploudTimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "文件类型";
            this.typeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.Width = 70;
            // 
            // subjectDataGridViewTextBoxColumn
            // 
            this.subjectDataGridViewTextBoxColumn.DataPropertyName = "Subject";
            this.subjectDataGridViewTextBoxColumn.HeaderText = "主题";
            this.subjectDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.subjectDataGridViewTextBoxColumn.Name = "subjectDataGridViewTextBoxColumn";
            this.subjectDataGridViewTextBoxColumn.Width = 50;
            // 
            // lengthDataGridViewTextBoxColumn
            // 
            this.lengthDataGridViewTextBoxColumn.DataPropertyName = "Length";
            this.lengthDataGridViewTextBoxColumn.HeaderText = "文件大小";
            this.lengthDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lengthDataGridViewTextBoxColumn.Name = "lengthDataGridViewTextBoxColumn";
            this.lengthDataGridViewTextBoxColumn.Width = 75;
            // 
            // downloadTimesDataGridViewTextBoxColumn
            // 
            this.downloadTimesDataGridViewTextBoxColumn.DataPropertyName = "DownloadTimes";
            this.downloadTimesDataGridViewTextBoxColumn.HeaderText = "下载次数";
            this.downloadTimesDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.downloadTimesDataGridViewTextBoxColumn.Name = "downloadTimesDataGridViewTextBoxColumn";
            this.downloadTimesDataGridViewTextBoxColumn.Width = 75;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "文件描述";
            this.descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Width = 150;
            // 
            // FileInfo_bds
            // 
            this.FileInfo_bds.DataSource = typeof(FileSharingWinform.Model.FileItem);
            // 
            // SearchResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SearchResultForm";
            this.Text = "SearchResultForm";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileResultVIew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileInfo_bds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView FileResultVIew;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.BindingSource FileInfo_bds;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uploudTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn downloadTimesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
    }
}