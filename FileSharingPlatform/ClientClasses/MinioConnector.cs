using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientClasses
{
    public class MinioConnector
    {
        public static bool creatBucket(string ID)
        {
            //新建名为ID的用户桶
            return true;
        }
        public static bool deleteBucket(string ID)
        {
            //删除名为ID的用户桶
            return true;
        }
        public static bool addFile(string ID, string localFilePath, string targetPath) {
            //找到桶，结合指定路径和本地文件路径，添加文件
            return true;

        }
        public static bool deleteFile(string ID, string targetPath) {
            //找到桶，根据指定文件路径，删除文件
            return true;
        }
        public static Task getFile(string ID, string targetPath,string savepath) { 
           //找到桶，根据指定文件路径，传回下载文件的Task
        }
    }
}
