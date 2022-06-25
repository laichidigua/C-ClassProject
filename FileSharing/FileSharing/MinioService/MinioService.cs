using FileSharing.ServiceModel;
using Minio;

namespace FileSharing.MinioService
{
    public class MinioService
    {
        public async static Task<bool> creatBucket(MinioClient client,string bucketName)
        {
            try
            {
                var bucketExistArgs = new BucketExistsArgs()
                         .WithBucket(bucketName);
                var found = await client.BucketExistsAsync(bucketExistArgs);

                var location = "us-east-1";
                if (!found)
                {
                    var makeBucketArgs = new MakeBucketArgs()
                        .WithBucket(bucketName)
                        .WithLocation(location);
                    await client.MakeBucketAsync(makeBucketArgs);
                    return true;
                }
                //新建名为ID的用户桶
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"create bucket failed :{e}");
                return false;
            }
        }
        public static bool deleteBucket(string ID)
        {
            //删除名为ID的用户桶
            return true;
        }

        //上传文件操作
        public async static Task<bool> uploadFile(MinioClient client,string bucketName,string destPath,MemoryStream ms)
        {
             
            var location = "us-east-1";
            try
            {
                var bucketExistArgs = new BucketExistsArgs()
                     .WithBucket(bucketName);
                var found = await client.BucketExistsAsync(bucketExistArgs);
  
                if (!found)
                {
                    var makeBucketArgs = new MakeBucketArgs()
                        .WithBucket(bucketName)
                        .WithLocation(location);
                    await client.MakeBucketAsync(makeBucketArgs);
                }

                string objectType = ContentType.GetContentType(destPath.Substring(destPath.LastIndexOf(".") + 1));
                var metaData = new Dictionary<string, string>
                {
                    { "Test-Metadata", "Test  Test"}
                };
                var putObjectArgs = new PutObjectArgs()
                   .WithBucket(bucketName)
                   .WithContentType(objectType)
                   .WithObject(destPath)
                   .WithStreamData(ms)
                   .WithHeaders(metaData)
                   .WithObjectSize(ms.Length);
 
                //var partNumber = (int)(fileInfo.Length / MinimumPartSize) + 1;
                //var log = new LogHandler(partNumber);
                client.SetTraceOn();
                await client.PutObjectAsync(putObjectArgs);
               
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"upload failed Exception: {e}");
                return false;
            }
            finally
            {
                client.SetTraceOff();
            }

        }

        //删除文件
        public async static Task<bool> deleteFile(MinioClient client,string bucketName,string destPath)
        {
            try
            {
                var args = new RemoveObjectArgs()
               .WithBucket(bucketName)
               .WithObject(destPath);                   
                await client.RemoveObjectAsync(args);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"delete failed Exception: {e}");
                return false;
            }
        }

        public async static Task<MemoryStream> downloadFile(MinioClient client,string bucketName,string destPath)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                var args = new GetObjectArgs()
                    .WithBucket(bucketName)
                    .WithObject(destPath)
                    .WithCallbackStream(stream =>
                    {
                        stream.CopyTo(ms);
                        ms.Flush();
                        ms.Seek(0, SeekOrigin.Begin);
                    });
                await client.GetObjectAsync(args);
                return ms;
            }catch(Exception e)
            {
                Console.WriteLine($"download failed:{e}");
                return new MemoryStream();
            }
        }
    }
}
