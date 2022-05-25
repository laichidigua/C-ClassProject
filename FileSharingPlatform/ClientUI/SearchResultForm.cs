using ClientClasses;
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

    public partial class SearchResultForm : Form
    {
        public List<FileItem> results;
        public SearchResultForm()
        {
            InitializeComponent();
        }
        public SearchResultForm(List<FileItem> a) :this()
        {
            results= a;
            bindingSource1.DataSource = results;
        }
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
        //点击下载
        private void btn_download_Click(object sender, EventArgs e)
        {
            FileItem current= ((FileItem)bindingSource1.Current);
            if (current == null) return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            string localpath=saveFileDialog.FileName;
            if (localpath == null) return;
            MinioConnector.getFile(current.ClientId, current.Path, localpath);
        }
    }
}
