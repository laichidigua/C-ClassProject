using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSharingWinform
{
    public partial class UploadPanel : UserControl
    {
        public string selectedPath { set; get; }
        public string discrip { set; get; }
        public bool isPrivate { set; get; }
        public  string Subject { set; get; }
        public string Filename { set; get; }
        public UploadPanel()
        {
            InitializeComponent();
            selectedPath = "default";
            discrip = "default";
            Subject = "default";

        }

        private void btn_chosefile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName == null || ofd.FileName == "") { return; }
            selectedPath = System.IO.Path.GetFullPath(ofd.FileName);
            label_filename.Text= System.IO.Path.GetFullPath(ofd.FileName);
            Filename= System.IO.Path.GetFileName(ofd.FileName); 

        }

        private void btn_confirminfo_Click(object sender, EventArgs e)
        {
            isPrivate= chkBox_private.Checked;
            discrip= txBox_discrip.Text;
            Subject = txBox_subject.Text;
            if (discrip == "")
            {
                discrip = "default";
            }
            if (Subject == "")
            {
                Subject = "default";
            }
            if (selectedPath == "default")
            {
                MessageBox.Show("请选择文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (discrip == "default")
            {
                MessageBox.Show("请填写文件描述信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Subject == "default")
            {
                MessageBox.Show("请填写文件主题！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                MessageBox.Show("信息填写完成，点击上传按钮以上传文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }
    }
}
