using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingWinform.Model
{


    internal class Client
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Password { get; set; }
        public Client() { }
        public Client(string id, string name, DateTime time, string password) { Id = id; Name = name; Created = time; Password = password; }
    }
}

