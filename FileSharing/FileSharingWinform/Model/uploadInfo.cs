using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingWinform.Model
{
    internal class uploadInfo
    {
        public uploadInfo(string id, string password, string destPath, IFormFile file)
        {
            Id = id;
            Password = password;
            this.destPath = destPath;
            this.file = file;

        }

        HttpClient httpClient = new HttpClient();



        public string Id { get; set; }

        public string Password { get; set; }

        public string destPath { get; set; }

        public IFormFile file { get; set; }
    }
}

