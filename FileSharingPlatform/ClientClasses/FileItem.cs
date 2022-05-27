using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientClasses
{
    public class FileItem
    {
        public FileItem() { }
        public FileItem(string clientid,string filename,string discription,string path,bool isprivate) { 
            ClientId = clientid;
            FileName = filename;
            Description = discription;
            CreatedTime= DateTime.Now;
            Path = path;
        }
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Path { set; get; }

        public bool isPrivate { set; get; }

        
    }
}
