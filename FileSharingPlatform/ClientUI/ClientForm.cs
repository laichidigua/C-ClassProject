using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientClasses;
namespace ClientUI
{

    public partial class ClientForm : Form
    {
        //上传文件面板。当树组件选的不是叶子的时候，面板显示为此面板
        //面板中保存着要上传文件的本地路径，文件描述，和是否私有属性
        public uploadPanel uploadPanel;
        //文件信息面板，当当树组件选的是叶子的时候，面板显示为此面板
        //该面板通过得知树组件所选择的路径，到ES中获取到文件概要信息进行展示
        public InformationPanel informationPanel;
        
        //该属性，由登录界面的ID赋值
        public string ClientId { set; get; }

        //该属性表示树组件用户点击的路径。每次点击都会更新
        public string targetPath { set; get; }

        public ClientForm()
        {
            InitializeComponent();
            //初始时，上传点击按钮都不能点
            btn_download.Enabled = false;
            btn_upload.Enabled = false;
        }
        public ClientForm(string id) : this() { 
            ClientId = id;
            //新建代表桶的唯一根节点
            tree_file.Nodes.Add(new TreeNode(id));
            //根据MINIO中的所有文件构建出树组件
            initialTreeView(new List<string> { @"123\456\789",@"123\444\841"});
        }
        //构建树组件
        public void initialTreeView(List<string> paths) { 
            //todo
            List<string> list = paths;
            
            foreach (string item in list) {
                TreeNode currentNode=tree_file.Nodes[0];
                string[] vs = item.Split('\\');
                for (int i = 0; i < vs.Length; i++) {
                    if  (hasNode(currentNode, vs[i])!=null) {
                        TreeNode nextNode = hasNode(currentNode, vs[i]);
                        currentNode = nextNode;
                        continue;

                    }
                    TreeNode newNode=new TreeNode(vs[i]);
                    currentNode.Nodes.Add(newNode);
                    currentNode = newNode;
                }
            }
        }
        //辅助构建树组件方法
        private TreeNode hasNode(TreeNode treeNode, string name) {
            foreach (TreeNode node in treeNode.Nodes) { 
                if(node.Text==name)return node;
            }
            return null;
        }
        //树组件鼠标点击事件，点击为叶则显示下载按钮和文件概要信息
        //点击非叶子，显示上传按钮，加上传界面
        //两者都会改变targetPath属性
        private void tree_file_AfterSelect(object sender, TreeViewEventArgs e)
        {
            targetPath = tree_file.SelectedNode.FullPath;
            btn_download.Enabled = false;
            btn_upload.Enabled = false;
            if (tree_file.SelectedNode.Nodes.Count == 0)
            {
                btn_download.Enabled = true;
                panel3.Controls.Clear();
                InformationPanel a = new InformationPanel(ClientId, tree_file.SelectedNode.FullPath);
                panel3.Controls.Add(a);
                this.informationPanel = a;
            }
            else {
                panel3.Controls.Clear();
                uploadPanel b = new uploadPanel();
                panel3.Controls.Add(b);
                this.uploadPanel = b;
                btn_upload.Enabled = true;
            }

        }
        //上传按钮点击
        //判断上传界面是否显示，若显示
        //则读取上传文件的信息：选择的本地文件路径，描述，是否私有
        //并构建出文件条目上传到ES
        //同时在minio中新建文件
        private void btn_upload_Click(object sender, EventArgs e)
        {
            if (uploadPanel == null) { return; }
            string[] localpaths=uploadPanel.selectedPath.Split('\\');
            string discription = uploadPanel.discrip;
            bool isprivate = uploadPanel.isPrivate;
            string[] targetpaths=targetPath.Split('\\');
            targetPath.Remove(0,targetpaths[0].Length+1);
            ESConnector.creatItem(new FileItem(ClientId,localpaths[localpaths.Length-1],discription,targetPath,isprivate));
            MinioConnector.addFile(ClientId,uploadPanel.selectedPath, targetPath);
        }
        //下载点击
        //直接从minio中获取文件
        private void btn_download_Click(object sender, EventArgs e)
        {
            string[] targetpaths = targetPath.Split('\\');
            targetPath.Remove(0, targetpaths[0].Length + 1);
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            string savepath=save.FileName;
            MinioConnector.getFile(ClientId, targetPath,savepath);
        }

        //搜索按钮
        //根据搜索语句到ES中查询，得到list<fileItem>
        //进入搜索展示页面
        private void btn_search_Click(object sender, EventArgs e)
        {
            List<FileItem> result= ESConnector.search(textBox1.Text);
            new SearchResultForm(result).ShowDialog();
        }
    }
}
