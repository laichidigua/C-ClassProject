using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
namespace FileSharingWinform
{
    public partial class RegisterForm : Form
    {
        public static readonly HttpClient httpClient = new HttpClient();
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userID = TextBox_userID.Text;
            string password =TextBox_password.Text;
            var response = httpClient.GetAsync(@"https://localhost:7190/MinioService/register?clientid="+userID+"&&name=unknown&&password="+password).Result.Content.ReadAsStringAsync().Result;
            
            if (response == "true")
            {
                MessageBox.Show("注册成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("您输入的用户名已被注册！","提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
