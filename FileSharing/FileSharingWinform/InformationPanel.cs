using FileSharingWinform.Model;
using Newtonsoft.Json;
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
    public partial class InformationPanel : UserControl
    {
        string Filename { set; get; }

        public InformationPanel()
        {
            InitializeComponent();
        }
        public InformationPanel(string ID, string path) : this()
        {

            HttpClient httpClient = new HttpClient();

            var response = httpClient.GetAsync(@"https://localhost:7190/MinioService/fileitem?clientid=" + ID + "&"+"&path=" + path )
            .Result.Content.ReadAsStringAsync().Result;
            
            //var response = httpClient.GetAsync(builder.ToString())
            //.Result.Content.ReadAsStringAsync().Result;*/
            FileItem fileItem = JsonConvert.DeserializeObject<FileItem>(response);
            label_username.Text = fileItem.ClientId;
            label_filename.Text = fileItem.Name;
            label_description.Text = fileItem.Description;
            
        }

        private void label_filename_Click(object sender, EventArgs e)
        {

        }
    }
}
