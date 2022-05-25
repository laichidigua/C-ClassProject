using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientClasses
{
    public class MysqlConnector
    {
        public static bool addClient(Client client) { 
            if(client ==null)return false;
            using (var context = new ClientContext()) { 
                context.Clients.Add(client);
                context.SaveChanges();
            }
                return true; 
        }
        public static bool deleteClient(Client client) {
            using (var context = new ClientContext())
            {
                var result = context.Clients.FirstOrDefault(x => x.Id == client.Id);
                if (client == null) return false;
                context.Clients.Remove(result);
                context.SaveChanges();
            }
            return true; 
        }
        public static bool IsPasswordRight(string id,string password) {
            //从数据库中读取信息，判断密码是否正确
            using (var context = new ClientContext())
            {
               var client=context.Clients.SingleOrDefault(c => c.Id == id);
                if (client == null) return false;
                if(client.Password==password)return true;
            }
            
            return false;
        }
    }
}
