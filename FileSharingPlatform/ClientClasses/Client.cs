﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientClasses
{

    public class Client
    {
        
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        Client() {
            Id = Guid.NewGuid().ToString();
        }
        Client(string name, string password):this() 
        {
            Name = name;
            Password = password;
            //为用户建桶
            //将用户信息存入数据库
        }
        public override bool Equals(object obj)
        {
            var client = obj as Client;
            return client != null &&
                   Id == client.Id &&
                   Name == client.Name;
        }
        public override int GetHashCode()
        {
            var hashCode = 1479869798;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}