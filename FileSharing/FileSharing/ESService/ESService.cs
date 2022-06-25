using Nest;
using FileSharing.Model;
namespace FileSharing.ESService
{
    public class ESService
    {
        public static ElasticClient elasticClient { get; set; }
        //初始化elasticClient，若没有表则建表，自动mapping
        public static void getConnection()
        {
            var settings = new ConnectionSettings(new Uri("http://127.0.0.1:9200")).DefaultIndex("default");
            elasticClient = new ElasticClient(settings);
            if (!elasticClient.Indices.Exists("client").Exists) { var createIndexResponse = elasticClient.Indices.Create("client", c => c.Map<Client>(m => m.AutoMap())); }
            if (!elasticClient.Indices.Exists("fileitem").Exists) { var createIndexResponse1 = elasticClient.Indices.Create("fileitem", c => c.Map<FileItem>(m => m.AutoMap())); }
        }
        public static bool checkClientId(string clientid) {
            if (ESService.findClientById(clientid) == null) return false;
            else return true;
        }
        public static bool register(string clientid,string name,string password) {
            if (ESService. checkClientId(clientid)==true) return false;
            ESService.indexClient(new Client(clientid,name,DateTime.Now,password));
            return true;
        }
        //存入Client
        public static bool indexClient(Client client)
        {
            var indexResponse = elasticClient.Index(client, i => i.Index("client"));
            return indexResponse.IsValid;
        }
        //存入FileItem,同位置已有同名文件则更新除id之外的属性
        public static bool indexFileItem(FileItem fileItem)
        {
            var file = getFileItemByClientIdAndPath(fileItem.ClientId,fileItem.Path);
            if (file != null) { fileItem.Id = file.Id; }

            var indexResponse = elasticClient.Index(fileItem, i => i.Index("fileitem"));
            return indexResponse.IsValid;
        }
        //全文搜索，根据String查询Name、Description字段，返回FileItem列表.公有+非引用+非文件夹
        public static List<FileItem> findFileItemByString(string context)
        {
            var searchResponse = elasticClient.Search<FileItem>(s => s.Index("fileitem").From(0).Size(20).Query(q => q
            .QueryString(m => m
                .Fields(f => f
                    .Field(d => d.Description)
                    .Field(a => a.Name)
                    .Field(c=>c.Subject))
                    .Query(context)
                    ) && q.Bool(aa => aa.Must(
                            bb => bb.Term(pp=>pp.IsPrivate,false),
                            bb=>bb.Term(cc=>cc.IsReference,false),
                            bb=>bb.Term(dd=>dd.IsDictionary,false)
                        )) ).Sort(st=>st.Descending(pp=>pp.DownloadTimes))
            ) ;
            var files = searchResponse.Documents;
            return files.ToList();
        }
        //根据科目查询。公有+非引用+非文件夹
        public static List<FileItem> findFileItemBySubject(string subject) {
            var searchResponse = elasticClient.Search<FileItem>(s => s.Index("fileitem").From(0).Size(10).Query(q => q
            .QueryString(m => m
                .Fields(f => f
                    .Field(d => d.Subject))
                    .Query(subject))&&q.Bool(aa => aa.Must(
                            bb => bb.Term(pp => pp.IsPrivate, false),
                            bb => bb.Term(cc => cc.IsReference, false),
                            bb => bb.Term(dd => dd.IsDictionary, false)
                        ))
            ).Sort(st => st.Descending(pp => pp.DownloadTimes)));
            var files = searchResponse.Documents;
            return files.ToList();
        }
        //查询指定id的用户，返回client
        public static Client findClientById(string clientid)
        {
            try
            {
                var searchResponse = elasticClient.Search<Client>(s => s
                    .Index("client")
                    .Query(q => q
                        .Term(a => a.Id, clientid)));
                var client = searchResponse.Documents;
                return client.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
        //查询指定id的用户的密码，返回string
        public static string findClientPasswordById(string clientid) {
            return findClientById(clientid).Password;
        }
        //更新指定id的用户的密码，返回bool
        public static bool updateClientPasswordById(string clientid, string oldpassword, string newpassword) { 
            var client = findClientById(clientid);
            if (client.Password == oldpassword) { 
                client.Password = newpassword; 
                indexClient(client);return true; 
            }
            else { 
                return false; 
            }
        }
        //判断密码是否正确
        public static bool isPasswordRight(string clientid, string password) {
            var pass=findClientPasswordById(clientid);
            if (pass == password) { return true; }
            else { return false; }
        }
        //获取指定用户全部文件路径,用于前端渲染树状图
        public static List<string> getAllFileItemPathByClientId(string clientid) {
            var result = new List<string>();
            var fileitems = getFileItemsByClientId(clientid);
            if (fileitems == null) { return result; }
            //若为引用类型的文件，则先查看其引用的文件现在还是否是公开的
            foreach (FileItem fileItem in fileitems) {
                if (fileItem.IsReference == true)
                {
                    var trueFileItem = getFileItemById(fileItem.ReferenceFileId);
                    if (trueFileItem == null) { continue; }
                    if (trueFileItem.IsPrivate == false)
                    {
                        result.Add(fileItem.Path);
                    }
                    else { continue; }
                }
                else { result.Add(fileItem.Path); }
            }
            return result;
        }
        //获取指定id的文件
        public static FileItem getFileItemById(string fileid) {
            var searchResponse = elasticClient.Search<FileItem>(s => s.Index("fileitem").Query(q => q
            .Match(m => m
                .Field(a => a.Id)
                .Query(fileid))));
            return searchResponse.Documents.ToList().FirstOrDefault();
        }
        //获取指定用户id的所有文件
        public static List<FileItem> getFileItemsByClientId(string clientid) {
            var searchResponse = elasticClient.Search<FileItem>(s => s.Index("fileitem").Query(q => q.Term(c => c.ClientId, clientid)));
                //.Match(m => m
                 //   .Field(a => a.ClientId)
                 //   .Query(clientid))));
            return searchResponse.Documents.ToList();

        }
        //删除指定id的文件
        public static bool deleteFileItemById(string fileid) {
            var deleteResponse = elasticClient.DeleteByQuery<FileItem>(s=>s.Index("fileitem").Query(q=>q
                .Match(m => m
                    .Field(a=>a.Id)
                    .Query(fileid))));
            return deleteResponse.IsValid;
        }
        //删除指定用户、路径的文件
        public static bool deleteFileItemByClientIdAndPath(string clientid, string path) {
            var deleteResponse = elasticClient.DeleteByQuery<FileItem>(s => s.Index("fileitem").Query(q => q
                .Bool(m => m
                    .Must(a => a
                        .Term(c => c.ClientId, clientid), a => a
                        .Term(u => u.Path, path)))));
            return deleteResponse.IsValid;
        }
        //删除指定用户、路径的文件夹
        public static bool deleteDictionary(string clientid ,string path) {
            var deleteResponse = elasticClient.DeleteByQuery<FileItem>(s => s.Index("fileitem").Query(q => q
                .Bool(m => m
                    .Must(a => a
                        .Term(c => c.ClientId, clientid), a => a
                        //.Match(b=>b.Field(c=>c.Path).Query(path))
                        .Prefix(b=>b.Field(h=>h.Path).Value(path)))
                        )));
            return deleteResponse.IsValid;
        }
        //获取指定文件夹下所有文件path
        public static List<string> getAllPathsByDictionary(string clientid, string path) {
            var result=new List<string>();
            var searchResponse = elasticClient.Search<FileItem>(s => s.Index("fileitem").Query(q => q
               .Bool(m => m.Must(a => a
                        .Term(c => c.ClientId, clientid)
                        , a => a.Prefix(b => b.Field(c => c.Path).Value(path))

                   )

                )));
            foreach (FileItem file in searchResponse.Documents.ToList()) {
                if (file.ClientId == clientid&&file.IsReference==false) {
                    result.Add(file.Path);
                }
            
            }
            return result;
        }
        //获取指定用户id,指定path的FileItem
        public static FileItem getFileItemByClientIdAndPath(string clientid, string path) {
            var searchResponse = elasticClient.Search<FileItem>(s=>s.Index("fileitem").Query(q=>q
            .Bool(b=>b
                .Must(a=>a
                    .Term(c=>c.ClientId,clientid),a=>a
                    .Term(u=>u.Path,path)))));
            return searchResponse.Documents.ToList().FirstOrDefault();
        }
        //用户移动该文件到别的位置
        public static bool moveFileItem(string clientid, string path, string newpath) { 
            var fileitem=getFileItemByClientIdAndPath(clientid, path);
            if (fileitem == null) { return false; }
            var fileitem1= getFileItemByClientIdAndPath(clientid, newpath);
            if (fileitem1 != null) { return false; }
            fileitem.Path = newpath;
            return indexFileItem(fileitem);
        }
        //用户下载别人的，指定用户id，指定path的文件,只对下载量++
        public static bool downloadFileItem(string clientid, string path) {
            var fileitem = getFileItemByClientIdAndPath(clientid, path);
            if (fileitem == null) { return false; }
            if (fileitem.IsReference == true) { return false; }
            if (fileitem.IsPrivate == true) { return false; }
            fileitem.DownloadTimes++;
            return indexFileItem(fileitem);
        }
        //用户上传文件，在ES中创建条目,已经存在则false
        public static bool uploadFileItem(string clientid,string dictionarypath,string name,string description,bool isprivate,string subject,double length) {
            if (dictionarypath == "")
            {
                var file = getFileItemByClientIdAndPath(clientid, name);
                if (file != null) { return false; }
                string[] split = name.Split(".");
                var fileitem = new FileItem(Guid.NewGuid().ToString(), name, description, isprivate, clientid, name, DateTime.Now, split[1], subject, length, false, "", false);
                return indexFileItem(fileitem);
            }
            else
            {
                var file = getFileItemByClientIdAndPath(clientid, dictionarypath + @"\" + name);
                if (file != null) { return false; }
                string[] split = name.Split(".");
                var fileitem = new FileItem(Guid.NewGuid().ToString(), name, description, isprivate, clientid, dictionarypath + @"\" + name, DateTime.Now, split[1], subject, length, false, "", false);
                return indexFileItem(fileitem);
            }
        }
        //用户添加文件夹，在ES中创建条目,已经存在则false
        public static bool uploadDictionary(string clientid,string dictionarypath,string name) {
            
            
            if (dictionarypath == "") { var file = getFileItemByClientIdAndPath(clientid, name);
                if (file != null) { return false; }
                var fileitem = new FileItem(Guid.NewGuid().ToString(), name, "", true, clientid, name, DateTime.Now, "", "", 0.0, false, "",true);
                return indexFileItem(fileitem);

            }
            else
            {
                var file = getFileItemByClientIdAndPath(clientid, dictionarypath + @"\" + name);
                if (file != null) { return false; }
                var fileitem = new FileItem(Guid.NewGuid().ToString(), name, "", true, clientid, dictionarypath + @"\" + name, DateTime.Now, "", "", 0.0, false, "",true);
                return indexFileItem(fileitem);
            }
           
        }
        //添加到我的云盘,新添文件条目，但引用为true,并设置引用的文件id，更新时间
        public static bool addToMyFiles(string clientid,string dictionatypath,string fileid) {
            var fileitemfrom = getFileItemById(fileid);
            if (fileitemfrom == null) { return false; }
            if (fileitemfrom.IsReference == true) { return false; }
            if (fileitemfrom.IsPrivate == true) { return false; }
            var fileitemto = new FileItem(Guid.NewGuid().ToString(),fileitemfrom.Name,fileitemfrom.Description,true,clientid,dictionatypath+@"\"+fileitemfrom.Name,DateTime.Now,fileitemfrom.Type,fileitemfrom.Subject,fileitemfrom.Length,true,fileitemfrom.Id,false);
            return indexFileItem(fileitemto);
        }
        //Serach by date
        public static List<FileItem> findFileItemByDate (DateTime t1,DateTime t2) 
        {
            var searchResponse = elasticClient.Search<FileItem>(s => s
                .Query(q => q
                    .DateRange(r => r
                        .Field(f => f.UploudTime)
                        .GreaterThanOrEquals(t1)
                        .LessThan(t2))));
            var files = searchResponse.Documents;
            return files.ToList();
        }
    }
}