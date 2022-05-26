using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientClasses
{
    internal class ESConnector
    {

        public static bool creatItem(FileItem fileItem) {
            //解析fileItem字段，生成json语句，通过api存入ES
            return true;
        }
        public static bool deleteItem(string ID) { 
            //根据文件ID查找并删除
            return true; 
        }
        public static List<FileItem> search(string sentence) { 
            return new List<FileItem>();
        }
        public static bool updateItem(FileItem fileItem) {
            //根据id，先删再添
            return true;
        }
    }
}
