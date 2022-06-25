using FileSharing.Model;
using FileSharing.ServiceModel;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Newtonsoft.Json;
using System.IO;

namespace FileSharing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MinioServiceController : ControllerBase
    {
        
        //发送get请求获取文件信息
        [HttpGet("")]
        public async Task<string> downloadObj()
        {
            
            return " ";
        }
        
        [HttpPost("download")]
        public MemoryStream downloadObj([FromForm]downloadInfo content)
        {
            ESService.ESService.getConnection();
            
            //下载，将对应文件下载量++
            ESService.ESService.downloadFileItem(content.Id,content.destPath);
            var file= ESService.ESService.getFileItemByClientIdAndPath(content.Id, content.destPath);
            if (file != null) {
                if (file.IsReference)
                {
                    var f1 = ESService.ESService.getFileItemById(file.ReferenceFileId);
                    content.Id = f1.ClientId;
                    content.Password = ESService.ESService.findClientPasswordById(f1.ClientId);
                    content.destPath = f1.Path;
                }
                else { content.Password = ESService.ESService.findClientPasswordById(content.Id); }
            }
            
            

            
            MinioClient client = new MinioClient().WithEndpoint("127.0.0.1:9000").WithCredentials(content.Id, content.Password)
                .Build();
            try
            {
                content.destPath=content.destPath.Replace('\\','/' );
                MemoryStream ms = MinioService.MinioService.downloadFile(client, content.Id, content.destPath).Result;
                return ms;
            }catch(Exception e)
            {
                Console.WriteLine($"download failed :{e}");
                return new MemoryStream();
            }
        }
        //发送post请求上传文件
        [HttpPost("upload")]
        public bool uploadObj([FromForm]uploadInfo content)
        {
            ESService.ESService.getConnection();
            if (!ESService.ESService.isPasswordRight(content.Id, content.Password)) { return false; }
            double length = 0.0;
            MinioClient client = new MinioClient().WithEndpoint("127.0.0.1:9000").WithCredentials(content.Id, content.Password)
                .Build();
            
            try {          
  
                using(MemoryStream ms=new MemoryStream())
                {

                    content.file.CopyTo(ms);
                    //获取文件大小
                    length = ms.Length;
                    ms.Flush();
                    ms.Seek(0, SeekOrigin.Begin);
                    MinioService.MinioService.uploadFile(client,content.Id,content.destPath, ms).Wait();
                }
                //ES存入相应条目
                ESService.ESService.uploadFileItem(content.Id,content.dictionarypath,content.name,content.description,content.isprivate,content.subject,length);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"load file failed:{e}");
                return false;
            }
        }

        //发送Delete请求删除某个文件
        [HttpPost("delete")]
        public bool deleteObj([FromForm]deleteInfo content)
        {
            
            ESService.ESService.getConnection();
            if (!ESService.ESService.isPasswordRight(content.Id, content.Password)) { return false; }
            
            ESService.ESService.deleteFileItemByClientIdAndPath(content.Id,content.destPath);

            MinioClient client = new MinioClient().WithEndpoint("127.0.0.1:9000").WithCredentials(content.Id,content.Password).Build();
            try
            {
                content.destPath = content.destPath.Replace('\\', '/');
                MinioService.MinioService.deleteFile(client,content.Id, content.destPath).Wait();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        [HttpGet("deletetest")]
        public bool deletetest(string clientid,string path) {
            ESService.ESService.getConnection();
            return ESService.ESService.deleteFileItemByClientIdAndPath(clientid,path);
        }
        //发送Delete请求删除某个文件夹
        [HttpGet("deleteall")]
        public bool deleteDictionary(string clientid,string password,string path)
        {
            ESService.ESService.getConnection();
            if (!ESService.ESService.isPasswordRight(clientid, password)) { return false; }
            MinioClient client = new MinioClient().WithEndpoint("127.0.0.1:9000").WithCredentials(clientid,password).Build();
            var paths = ESService.ESService.getAllPathsByDictionary(clientid,path);
            foreach (string str in paths) {
                try
                {
                    string str1=str.Replace('\\', '/');
                    
                    MinioService.MinioService.deleteFile(client, clientid, str1).Wait();
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            ESService.ESService.deleteDictionary(clientid,path);
           return true;
            
        }
     
        
        [HttpGet("paths")]
        public String getPaths(string clientid)
        {
            ESService.ESService.getConnection();
            var temp=ESService.ESService.getAllFileItemPathByClientId(clientid);  
            return JsonConvert.SerializeObject(temp);
        }

        [HttpGet("search")]
        public string searchString( string context) {
            ESService.ESService.getConnection();
            var temp= ESService.ESService.findFileItemByString(context);
            //var temp = new List<FileItem>();
            //temp.Add(new FileItem("test1","test.txt","test",false,"000001","test.txt",DateTime.Now,"txt","test",0.0,false,"-1",false));
            return JsonConvert.SerializeObject(temp);
        }

        [HttpGet("searchBySubject")]
        public string searchSubject(string subject)
        {
            ESService.ESService.getConnection();
            var temp= ESService.ESService.findFileItemBySubject(subject);
            return JsonConvert.SerializeObject(temp);
        }
        [HttpGet("check")]
        public bool checkPassword(string clientid,string password) {
            ESService.ESService.getConnection();
            return ESService.ESService.isPasswordRight(clientid,password);
        }
        [HttpGet("fileitem")]
        public string getFileItem(string clientid,string path) {
            ESService.ESService.getConnection();
            var temp=ESService.ESService.getFileItemByClientIdAndPath(clientid,path);
            return JsonConvert.SerializeObject(temp);
        }
        [HttpGet("addToMine")]
        public bool addToMine(string clientid,string dictionarypath,string fileid) {
            ESService.ESService.getConnection();
            return ESService.ESService.addToMyFiles(clientid,dictionarypath,fileid);
        }

        [HttpGet("register")]
        public bool registerClient(string clientid,string name,string password) {
            ESService.ESService.getConnection();
             ESService.ESService.register(clientid,name,password);

           return ESService.ESService.uploadDictionary(clientid,"","我的收藏");
        }

        [HttpGet("newdictionary")]
        public bool newDictionary(string clientid, string dictionarypath, string dictionaryname)
        {
            ESService.ESService.getConnection();
            if (dictionarypath == clientid) { return ESService.ESService.uploadDictionary(clientid, "", dictionaryname); }
            return ESService.ESService.uploadDictionary(clientid, dictionarypath, dictionaryname);
        }

    }
}
