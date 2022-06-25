using Nest;

namespace FileSharing.Model
{
    [ElasticsearchType(Name = "fileitem")]
    public class FileItem
    {
        public string Id { set; get; }
        [Text(Analyzer = "ik_max_word", Name = "name")]
        public string Name { get; set; }
        [Text(Analyzer = "ik_smart", Name = "description")]
        public string Description { get; set; }
        [Boolean(Name = "isprivate")]
        public bool IsPrivate { get; set; }
        [Keyword(Name = "clientid")]
        public string ClientId { get; set; }
        [Keyword(Name = "path")]
        public string Path { get; set; }
        [Date(Name = "uploadtime")]
        public DateTime UploudTime { get; set; }
        [Text(Analyzer = "ik_max_word", Name = "type")]
        public string Type { get; set; }
        [Text(Analyzer = "ik_max_word", Name = "Subject")]
        public string Subject { get; set; }
        [Number(NumberType.Double, Name = "length")]
        public double Length { get; set; }
        [Boolean(Name = "isreference")]
        public bool IsReference { set; get; }
        [Keyword(Name = "referencefileid")]
        public string ReferenceFileId { set; get; }
        [Number(NumberType.Integer,Name ="downloadtimes")]
        public int DownloadTimes { set; get; }
        [Boolean(Name = "isdictionary")]
        public bool IsDictionary { set; get; }
        public FileItem(string id, string name, string description, bool isprivate, string clientid,string path, DateTime time, string type, string subject, double length, bool isreference, string referencefileid, bool isDictionary)
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
            IsDictionary = isDictionary;

        }
        public FileItem() { }
    }
}
