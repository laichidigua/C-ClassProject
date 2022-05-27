using Minio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientClasses
{
    public class MinioConnector
    {
        public static MinioClient clientMinio = null;

        //待完善，桶密码？
        public async static Task<bool> creatBucket(Client client)
        {
            try
            {
                var bucketExistArgs = new BucketExistsArgs()
                         .WithBucket(client.Id);
                clientMinio= new MinioClient()
                .WithEndpoint("")
                .WithCredentials(client.Name, client.Password);
                var found = await clientMinio.BucketExistsAsync(bucketExistArgs);

                var location = "us-east-1";
                if (!found)
                {
                    var makeBucketArgs = new MakeBucketArgs()
                        .WithBucket(client.Id)
                        .WithLocation(location);
                    await clientMinio.MakeBucketAsync(makeBucketArgs);
                    return true;
                }
                //新建名为ID的用户桶
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        //TODO
        public static bool deleteBucket(string ID)
        {
            //删除名为ID的用户桶
            return true;
        }
        //上传文件
        public static async Task<bool> uploadFile(Client client, string srcPath, string destPath)
        {
            if (!File.Exists(srcPath)) return false;
            var location = "us-east-1";
            try
            {
                clientMinio = new MinioClient()
                .WithEndpoint("")
                .WithCredentials(client.Name, client.Password);
                var bucketExistArgs = new BucketExistsArgs()
                     .WithBucket(client.Id);
                var found = await clientMinio.BucketExistsAsync(bucketExistArgs);

                if (!found)
                {
                    var makeBucketArgs = new MakeBucketArgs()
                        .WithBucket(client.Id)
                        .WithLocation(location);
                    await clientMinio.MakeBucketAsync(makeBucketArgs);
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

                clientMinio.SetTraceOn();

                await clientMinio.PutObjectAsync(putObjectArgs);


                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket]  Exception: {e}");
                return false;
            }
            finally
            {
                clientMinio.SetTraceOff();
            }

        }
        //下载文件到指定目录
        public static async Task<bool> downloadFile(Client client, string src, string dest)
        {
            clientMinio = new MinioClient()
                .WithEndpoint("")
                .WithCredentials(client.Name, client.Password);
            if (!File.Exists(dest)) return false;
            try
            {
                var bucketExistArgs = new BucketExistsArgs()
                     .WithBucket(client.Id);
                var found = await clientMinio.BucketExistsAsync(bucketExistArgs);
                if (!found) return false;


                var args = new GetObjectArgs()
                .WithBucket(client.Id)
                .WithObject(src)
                .WithFile(dest);
                var stat = await clientMinio.GetObjectAsync(args);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket]  Exception: {e}");
                return false;
            }
        }
        //todo
        public static bool deleteFile(string ID, string targetPath)
        {
            //找到桶，根据指定文件路径，删除文件
            return true;
        }
        //删除桶中的文件
        public static async Task<bool> deleteFile(Client client, string destPath)
        {
            clientMinio = new MinioClient()
                .WithEndpoint("")
                .WithCredentials(client.Name, client.Password);
            try
            {
                var bucketExistArgs = new BucketExistsArgs()
                     .WithBucket(client.Id);
                var found = await clientMinio.BucketExistsAsync(bucketExistArgs);

                if (!found)
                {
                    return false;
                }

                var args = new RemoveObjectArgs()
                .WithBucket(client.Id)
                .WithObject(destPath);

                await clientMinio.RemoveObjectAsync(args);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket]  Exception: {e}");
                return false;
            }

        }
        //返回桶中所有文件的字符串形式
        public static async Task<List<string>> getAllObjectInfo(Client client)
        {
            clientMinio = new MinioClient()
                .WithEndpoint("")
                .WithCredentials(client.Name, client.Password);
            List<string> res = new List<string>();
            try
            {
                var bucketExistArgs = new BucketExistsArgs()
                    .WithBucket(client.Id);
                var found = await clientMinio.BucketExistsAsync(bucketExistArgs);
                if (!found) throw new Exception("Bucket not found");

                var listArgs = new ListObjectsArgs()
                    .WithBucket(client.Id);
                var observable = clientMinio.ListObjectsAsync(listArgs);

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
