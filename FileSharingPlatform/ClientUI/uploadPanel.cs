using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientUI
{
    public partial class uploadPanel : UserControl
    {
        public string selectedPath { set; get; }
        public string discrip { set; get; }
        public bool isPrivate { set; get; }
        public uploadPanel()
        {
            InitializeComponent();
        }

        private void btn_selectfile_Click(object sender, EventArgs e)
        {
            openFileDialog1=new OpenFileDialog();
            openFileDialog1.ShowDialog();
            selectedPath=openFileDialog1.FileName;
        }

        private void discription_TextChanged(object sender, EventArgs e)
        {
            this.discrip=discription.Text;  
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.isPrivate = checkBox1.Checked;
        }
    }
}
