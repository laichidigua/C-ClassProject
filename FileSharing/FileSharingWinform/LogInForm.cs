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

namespace FileSharingWinform
{
    public partial class LogInForm : Form
    {
        static readonly HttpClient httpClient = new HttpClient();
        public LogInForm()
            
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userID = TextBox_userID.Text;
            string password = TextBox_password.Text;
            var response = httpClient.GetAsync(@"https://localhost:7190/MinioService/check?clientid="+userID+"&&password="+password).Result.Content.ReadAsStringAsync().Result;
           if (response == "true")
            {
             MainForm mainForm = new MainForm(userID,password);
             //MainForm mainForm = new MainForm();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
           }
           else {
               MessageBox.Show("密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           }

     
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.StartPosition= FormStartPosition.CenterScreen;
            registerForm.ShowDialog();
        }
    }
}
