using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientClasses
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ClientContext:DbContext
    {
        public ClientContext() : base("ClientDataBase") {
            Database.SetInitializer(
       new DropCreateDatabaseIfModelChanges<ClientContext>());
        }
        public DbSet<Client> Clients { get; set; }
    }
}
