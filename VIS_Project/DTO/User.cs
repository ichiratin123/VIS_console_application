using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }


        public User() { }
        public User(string username, string password, string name, string surname, string address, string phone, int roleId)
        {
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            Address = address;
            Phone = phone;
            RoleId = roleId;
        }

        public User(int id, string username, string password, string name, string surname, string address, string phone, int roleId)
        {
            UserId = id;
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            Address = address;
            Phone = phone;
            RoleId = roleId;
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
