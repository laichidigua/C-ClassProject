using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingWinform.Model
{
    internal class deleteInfo
    {
        public deleteInfo(string id, string password, string destPath)
        {
            Id = id;
            Password = password;
            this.destPath = destPath;
        }

        public string Id { get; set; }

        public string Password { get; set; }

        public string destPath { get; set; }
    }
}
