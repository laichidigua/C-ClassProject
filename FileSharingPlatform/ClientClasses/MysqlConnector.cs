using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientClasses
{
    public class MysqlConnector
    {
        public static bool addClient(Client client) { return true; }
        public static bool deleteClient(Client client) { return true; }
        public static bool IsPasswordRight(int id,string password) {
            //从数据库中读取信息，判断密码是否正确
            return true;
        }
    }
}
