namespace FileSharing.Model
{
    public class uploadInfo
    {
        public uploadInfo()
        {
        }

        public uploadInfo(string id, string password, string destPath, IFormFile file)
        {
            Id = id;
            Password = password;
            this.destPath = destPath;
            this.file = file;
        }

        public string Id { get; set; }

        public string Password { get; set; }

        public string destPath { get; set; }

        public string dictionarypath { get; set; }

        public string name { get; set; }
        public string description { get; set; }
        public bool isprivate { get; set; }
        public string subject { get; set; }

        public IFormFile file { get; set; }
    }
}
