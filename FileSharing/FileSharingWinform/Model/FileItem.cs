using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingWinform.Model
{

    public class FileItem
    {
        public string Id { set; get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPrivate { get; set; }

        public string ClientId { get; set; }

        public string Path { get; set; }

        public DateTime UploudTime { get; set; }

        public string Type { get; set; }

        public string Subject { get; set; }

        public double Length { get; set; }

        public bool IsReference { set; get; }

        public string ReferenceFileId { set; get; }

        public int DownloadTimes { set; get; }
        public FileItem(string id, string name, string description, bool isprivate, string clientid, string path, DateTime time, string type, string subject, double length, bool isreference, string referencefileid)
        {
            Id = id;
            Name = name;
            Description = description;
            IsPrivate = isprivate;
            ClientId = clientid;
            Path = path;
            UploudTime = time;
            Type = type;
            Length = length;
            IsReference = isreference;
            ReferenceFileId = referencefileid;
            Subject = subject;
        }
        public FileItem() { }
    }
}

