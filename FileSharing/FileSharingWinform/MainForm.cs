
using FileSharingWinform.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.IO;

namespace FileSharingWinform
{
    public partial class MainForm : Form
    {
        static readonly HttpClient httpClient = new HttpClient();
        //public Client client;
        //上传文件面板。当树组件选的不是叶子的时候，面板显示为此面板
        //面板中保存着要上传文件的本地路径，文件描述，和是否私有属性
        public UploadPanel uploadPanel;
        //文件信息面板，当当树组件选的是叶子的时候，面板显示为此面板
        //该面板通过得知树组件所选择的路径，到ES中获取到文件概要信息进行展示
        public InformationPanel informationPanel;
        //该属性，由登录界面的ID赋值
        public string ClientId { set; get; }
        public string Password { set; get; }

        //该属性表示树组件用户点击的路径。每次点击都会更新
        public string targetPath { set; get; }
        public string newfilename { set; get; }
        public string filename { set; get; }
        public MainForm()
        {
            InitializeComponent();
            btn_download.Enabled = false;
            btn_upload.Enabled = false;
            btn_creatfile.Enabled = false;
            btn_delete.Enabled = false;
           // tree_file.Nodes.Add(new TreeNode());
            //ClientId = "a";
            //initialTreeView(new List<string> { @"123\456\789.test", @"123\444\841.test" });
        }
        public MainForm(string id,string password) : this()
        {

             ClientId = id;
            Password= password;
            tree_file.Nodes.Add(new TreeNode(id));
            
            var response = httpClient.GetAsync(@"https://localhost:7190/MinioService/paths?clientid=" + ClientId).Result.Content.ReadAsStringAsync().Result;
            List<string> paths = JsonConvert.DeserializeObject<List<string>>(response);

            initialTreeView(paths);

        }
        //构建树组件
        public void initialTreeView(List<string> paths)
        {
            List<string> list = paths;

            foreach (string item in list)
            {
                TreeNode currentNode = tree_file.Nodes[0];
               /* if (!item.Contains('\\'))
                {
                    TreeNode newNode = new TreeNode(item);
                    currentNode.Nodes.Add(newNode);
                }
                else
                {*/
                    string[] vs = item.Split('\\');
                    for (int i = 0; i < vs.Length; i++)
                    {
                        if (hasNode(currentNode, vs[i]) != null)
                        {
                            TreeNode nextNode = hasNode(currentNode, vs[i]);
                            currentNode = nextNode;
                            continue;

                        }
                        TreeNode newNode = new TreeNode(vs[i]);
                        currentNode.Nodes.Add(newNode);
                        currentNode = newNode;
                    }
                //}
            }
        }
        //辅助构建树组件方法
        private TreeNode hasNode(TreeNode treeNode, string name)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                if (node.Text == name) return node;
            }
            return null;
        }




        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //树组件鼠标点击事件，点击为叶则显示下载按钮和文件概要信息
        //点击非叶子，显示上传按钮，加上传界面
        //两者都会改变targetPath属性
        private void tree_file_AfterSelect(object sender, TreeViewEventArgs e)
        {          
                    
            btn_download.Enabled = false;
            btn_upload.Enabled = false;
            btn_creatfile.Enabled = false;
            targetPath = tree_file.SelectedNode.FullPath;
            filename = tree_file.SelectedNode.Text;
            

            if (targetPath != ClientId)
            {
                btn_delete.Enabled = true;
                string[] targetpaths = targetPath.Split('\\');
                targetPath = targetPath.Substring(targetpaths[0].Length + 1);
            }


            
            if (tree_file.SelectedNode.Text.Contains("."))
            { 
                btn_download.Enabled = true;
                FileInfoPanel.Controls.Clear();
                InformationPanel a = new InformationPanel(ClientId, targetPath);
                a.Dock = DockStyle.Fill;
                FileInfoPanel.Controls.Add(a);
                this.informationPanel = a;
            }
            //判断为文件夹
            else
            {
               
                FileInfoPanel.Controls.Clear();
                UploadPanel b = new UploadPanel();
                b.Dock = DockStyle.Fill;
                FileInfoPanel.Controls.Add(b);
                this.uploadPanel = b;
                btn_upload.Enabled = true;
                btn_creatfile.Enabled = true;
            }
           //textBox_keyword.Text = targetPath;
        }
        

        //上传按钮点击
        //判断上传界面是否显示，若显示
        //则读取上传文件的信息：选择的本地文件路径，描述，是否私有
        //并构建出文件条目上传到ES
        //同时在minio中新建文件
        private void btn_upload_Click(object sender, EventArgs e)
        {
            
            if (uploadPanel == null) {
                return; }
            if (uploadPanel.selectedPath == "default" || uploadPanel.discrip == "default" || uploadPanel.Subject == "default")
            {
                MessageBox.Show("请完善文件详细信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(ClientId), "Id");
            content.Add(new StringContent(Password), "Password");
            if (targetPath == ClientId)
            {
                content.Add(new StringContent(uploadPanel.Filename), "destPath");
                content.Add(new StringContent(""), "dictionarypath");
            }
            else { content.Add(new StringContent(targetPath + "\\" + uploadPanel.Filename), "destPath");
                content.Add(new StringContent(targetPath), "dictionarypath");
            }
           
            
            content.Add(new StringContent(uploadPanel.discrip), "description");
            content.Add(new StringContent(uploadPanel.Filename), "name");
            content.Add(new StringContent(uploadPanel.isPrivate.ToString()), "isprivate");
            content.Add(new StringContent(uploadPanel.Subject), "subject");
            content.Add(new ByteArrayContent(System.IO.File.ReadAllBytes(uploadPanel.selectedPath)), "file", "nothing");
            var response = httpClient.PostAsync(@"https://localhost:7190/MinioService/upload", content)
                        .Result.Content.ReadAsStringAsync().Result.ToLower();
            if (response == "true")
            {
                tree_file.SelectedNode.Nodes.Add(new TreeNode(uploadPanel.Filename));
                MessageBox.Show("上传成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            if (response == "false")
            {
                MessageBox.Show("上传失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //ESConnector.creatItem(new FileItem(ClientId, localpaths[localpaths.Length - 1], discription, targetPath, isprivate));
            //await(MinioConnector.uploadFile(client, uploadPanel.selectedPath, targetPath));
        }
        //下载点击
        //直接从minio中获取文件
        private void btn_download_Click(object sender, EventArgs e)
        {
            /*
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            string savepath = save.FileName;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            string storage_path = System.IO.Path.GetFullPath(saveFileDialog.FileName);
            */


            var content = new MultipartFormDataContent();
            content.Add(new StringContent(ClientId), "Id");
            content.Add(new StringContent(Password), "Password");
            content.Add(new StringContent(targetPath), "destPath");
           
            /*string path = @"aa\1.jpg";
            path= path.Replace(@"\","/");
            content.Add(new StringContent(path), "destPath");*/
            var result =httpClient.PostAsync(@"https://localhost:7190/MinioService/download",content).Result.Content.ReadAsStreamAsync().Result;
            
            
            using(FileStream fs=new FileStream(filename, FileMode.Create))
            {
                result.Seek(0,SeekOrigin.Begin);
                    result.CopyTo(fs);
                    fs.Flush();
                MessageBox.Show("下载成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return;
            }
            //MessageBox.Show("下载失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            /*string[] targetpaths = targetPath.Split('\\');
            targetPath.Remove(0, targetpaths[0].Length + 1);
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            string savepath = save.FileName;*/
            //await MinioConnector.downloadFile(client, targetPath, savepath);
        }
        //搜索按钮
        //根据搜索语句到ES中查询，得到list<fileItem>
        //进入搜索展示页面

        private void btn_search_Click(object sender, EventArgs e)
        {
            string keyword = textBox_keyword.Text;

            if (textBox_keyword.Text == "") return;
            var response = httpClient.GetAsync(@"https://localhost:7190/MinioService/search?context=" + keyword).Result.Content.ReadAsStringAsync().Result;
            
            
            List<FileItem> fileItems = JsonConvert.DeserializeObject<List<FileItem>>(response);



           


            SearchResultForm searchResultForm = new SearchResultForm(fileItems,ClientId,targetPath);
            searchResultForm.refresh += RefreshForm; // 父窗口加入委托
            searchResultForm.StartPosition = FormStartPosition.CenterParent;
            searchResultForm.ShowDialog();
        }
        public void RefreshForm()// 父窗口 定义 委托具体逻辑
        {
            this.Close();
            MainForm newform = new MainForm(ClientId, Password);
            newform.StartPosition = FormStartPosition.CenterParent;
            newform.Show();
            
        }

        private void btn_creatfile_Click(object sender, EventArgs e)
        {
            newfilename = Interaction.InputBox("请输入新建文件名：", "提示", "",-1, -1);
            foreach(TreeNode treeNode in tree_file.SelectedNode.Nodes)
            {
                if(treeNode.Text== newfilename) { 
                    MessageBox.Show("文件夹名称重复！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);return; 

                }
            }
            if (newfilename == "") { return; }
            tree_file.SelectedNode.Nodes.Add( new TreeNode(newfilename));

            
            var response = httpClient.GetAsync(@"https://localhost:7190/MinioService/newdictionary?clientid=" + ClientId + "&&dictionarypath=" + targetPath + "&&dictionaryname=" + newfilename)
                .Result.Content.ReadAsStringAsync().Result;
            if(response=="true")MessageBox.Show("添加文件夹成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确定要删除该文件（夹）吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult.ToString() == "Yes")
            {
               
                if (tree_file.SelectedNode.Text.Contains("."))
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(ClientId), "Id");
                    content.Add(new StringContent(Password), "Password");
                    content.Add(new StringContent(targetPath), "destPath");
                    var response = httpClient.PostAsync(@"https://localhost:7190/MinioService/delete", content)
                        .Result.Content.ReadAsStringAsync().Result;
                   
                }
                else
                {
                    var response = httpClient.GetAsync(@"https://localhost:7190/MinioService/deleteall?clientid=" + ClientId + "&&password=" + Password + "&&path=" + targetPath)
                        .Result.Content.ReadAsStringAsync().Result;
                }
                tree_file.SelectedNode.Remove();
            }
            else { return; }
            
   
            
        }
    }
}
