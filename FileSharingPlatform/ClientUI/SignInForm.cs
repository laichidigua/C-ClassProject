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
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        //点击登录
        //判断账号密码是否正确，再根据id构建客户端窗口
        private void btn_login_Click(object sender, EventArgs e)
        {
            if (MysqlConnector.IsPasswordRight(ID.Text, password.Text))
            {
                this.Visible = false;
                new ClientForm(txt_ID.Text).ShowDialog();
            }
            else {
                //new FontDialog("无此账户或密码错误").ShowDialog();
            }

        }
    }
}
