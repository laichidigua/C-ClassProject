using Minio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientClasses
{
    internal class MinioConnector
    {
        public async static Task<bool> creatBucket(Client client)
        {
            try
            {
                var bucketExistArgs = new BucketExistsArgs()
                         .WithBucket(client.Id);
                var found = await client.Minio.BucketExistsAsync(bucketExistArgs);

                var location = "us-east-1";
                if (!found)
                {
                    var makeBucketArgs = new MakeBucketArgs()
                        .WithBucket(client.Id)
                        .WithLocation(location);
                    await client.Minio.MakeBucketAsync(makeBucketArgs);
                    return true;
                }
                //新建名为ID的用户桶
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public static bool deleteBucket(string ID)
        {
            //删除名为ID的用户桶
            return true;
        }
        public async Task<bool> uploadFile(Client client,string srcPath, string destPath)
        {
            if (!File.Exists(srcPath)) return false;
            var location = "us-east-1";
            try
            {
                var bucketExistArgs = new BucketExistsArgs()
                     .WithBucket(client.Id);
                var found = await client.Minio.BucketExistsAsync(bucketExistArgs);

                if (!found)
                {
                    var makeBucketArgs = new MakeBucketArgs()
                        .WithBucket(client.Id)
                        .WithLocation(location);
                    await client.Minio.MakeBucketAsync(makeBucketArgs);
                }

                string objectName = destPath + srcPath.Substring(srcPath.LastIndexOf(@"\"));
                string objectType = ContentType.GetContentType(srcPath.Substring(srcPath.LastIndexOf(".") + 1));

                var putObjectArgs = new PutObjectArgs()
                   .WithBucket(client.Id)
                   .WithContentType(objectType)
                   .WithFileName(srcPath)
                   .WithObject(objectName);

                var fileInfo = new FileInfo(srcPath);
                //var partNumber = (int)(fileInfo.Length / MinimumPartSize) + 1;
                //var log = new LogHandler(partNumber);

                client.Minio.SetTraceOn();

                await client.Minio.PutObjectAsync(putObjectArgs);


                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket]  Exception: {e}");
                return false;
            }
            finally
            {
                client.Minio.SetTraceOff();
            }

        }

        public async Task<bool> downloadFile(Client client,string src, string dest)
        {
            if (!File.Exists(dest)) return false;
            try
            {
                var bucketExistArgs = new BucketExistsArgs()
                     .WithBucket(client.Id);
                var found = await client.Minio.BucketExistsAsync(bucketExistArgs);
                if (!found) return false;


                var args = new GetObjectArgs()
                .WithBucket(client.Id)
                .WithObject(src)
                .WithFile(dest);
                var stat = await client.Minio.GetObjectAsync(args);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket]  Exception: {e}");
                return false;
            }
        }
        public static bool deleteFile(string ID, string targetPath) {
            //找到桶，根据指定文件路径，删除文件
            return true;
        }

        public async Task<bool> deleteFile(Client client,string destPath)
        {                
            try
            {
                var bucketExistArgs = new BucketExistsArgs()
                     .WithBucket(client.Id);
                var found = await client.Minio.BucketExistsAsync(bucketExistArgs);

                if (!found)
                {
                    return false;
                }
 
                var args = new RemoveObjectArgs()
                .WithBucket(client.Id)
                .WithObject(destPath);

                await client.Minio.RemoveObjectAsync(args);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket]  Exception: {e}");
                return false;
            }
       
        }
        public static Task getFile(string ID, string targetPath) { 
           //找到桶，根据指定文件路径，传回下载文件的Task
        }

        public async Task<List<string>> getAllObjectInfo(Client client)
        {
            List<string> res = new List<string>();
            try
            {
                var bucketExistArgs = new BucketExistsArgs()
                    .WithBucket(client.Id);
                var found = await client.Minio.BucketExistsAsync(bucketExistArgs);
                if (!found) throw new Exception("Bucket not found");

                var listArgs = new ListObjectsArgs()
                    .WithBucket(client.Id);
                var observable = client.Minio.ListObjectsAsync(listArgs);

                observable.Subscribe(item =>
                    res.Add(item.Key)
                    , ex => {
                    }
                    , () =>
                    {

                    }
                );

                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return res;
            }
        }


    }

    public static class ContentType
    {
        private static readonly Dictionary<string, string> DictionaryContentType = new Dictionary<string, string>
        {
            {"default","application/octet-stream"},
            {"bmp","application/x-bmp"},
            {"doc","application/msword"},
            {"docx","application/msword"},
            {"exe","application/x-msdownload"},
            {"gif","image/gif"},
            {"html","text/html"},
            {"jpg","image/jpeg"},
            {"mp4","video/mpeg4"},
            {"mpeg","video/mpg"},
            {"mpg","video/mpg"},
            {"ppt","application/x-ppt"},
            {"pptx","application/x-ppt"},
            {"png","image/png"},
            {"rar","application/zip"},
            {"txt","text/plain"},
            {"xls","application/x-xls"},
            {"xlsx","application/x-xls"},
            {"zip","application/zip"},
        };

        public static string GetContentType(string fileExtension)
        {
            return DictionaryContentType.ContainsKey(fileExtension) ? DictionaryContentType[fileExtension] : DictionaryContentType["default"];
        }

    }
}
