using FileSharingWinform.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FileSharingWinform
{
    public partial class SearchResultForm : Form
    {
        public delegate void RefreshDelegate(); // 子窗口声明定义委托 refresh()
        public event RefreshDelegate refresh;
        string clientid;
        string Path;
        public SearchResultForm()
        {
            InitializeComponent();
            FileInfo_bds.DataSource= null;

        }
        //传入FileInfo对象用于datagridview显示
        public SearchResultForm(List<FileItem> filelist,string clientid, string path) : this()

        {
            FileInfo_bds.DataSource = filelist;
            this.clientid = clientid;
            Path = path;
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            FileItem  fileitem =FileInfo_bds.Current as FileItem;
            string userID = fileitem.ClientId;
            string path = fileitem.Path;
            HttpClient httpClient = new HttpClient();
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(fileitem.ClientId), "Id");
            content.Add(new StringContent(""), "Password");
            content.Add(new StringContent(fileitem.Path), "destPath");
            var result = httpClient.PostAsync(@"https://localhost:7190/MinioService/download", content).Result.Content.ReadAsStreamAsync().Result;

            using (FileStream fs = new FileStream(fileitem.Name, FileMode.Create))
            {
                result.CopyTo(fs);
                fs.Flush();
                MessageBox.Show("下载成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("下载失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            FileItem fileitem = FileInfo_bds.Current as FileItem;
            string fileID = fileitem.Id;
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(@"https://localhost:7190/MinioService/addToMine?clientid=" + clientid + "&&dictionarypath=我的收藏" + "&&fileid="+fileitem.Id)
                .Result.Content.ReadAsStringAsync().Result;

            if (response == "true")
            { 
                MessageBox.Show("加入我的云盘成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                this.refresh(); // 调用委托

            }
            else
            {
                MessageBox.Show("加入我的云盘失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
