using DL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BL
{
    public class BLUser
    {
        private User_TDG userTDG = new User_TDG();
        
        public BLUser() { }

        public int createUser(User user)
        {
            string username = user.Username;
            int id = userTDG.GetUserIdByUsername(username);
            if (userTDG.UserExists(username))
            {
                return -1;
            }
            else
            {
                string password = user.Password;
                string name = user.Name;
                string surname = user.Surname;
                string address = user.Address;
                string phone = user.Phone;
                int roleid = user.RoleId;
                User userData = new User(id, username, password, name, surname, address, phone, roleid);
                userTDG.CreateUser(userData);
                return 0;
            }
        }

        


        public User checkLogin(User user) {
            string username = user.Username;
            string password = user.Password;
            User getData = userTDG.FindUser(username, password);
            if (userTDG.checkLogin(username, password)) {
                User userData = new User(getData.UserId, getData.Username, getData.Password,getData.Name, getData.Surname, getData.Address, getData.Phone, getData.RoleId);
                return userData;
            }else
            {
                return null;
            }
        }

        public List<User> GetAllUser()
        {
            List<User> u2 = userTDG.GetAllUsers();
            List<User> u1 = new List<User>();
            foreach (User i in u2)
            {
                User user = new User(i.UserId, i.Username, i.Password, i.Name, i.Surname, i.Address, i.Phone, i.RoleId);
                u1.Add(user);
            }
            return u1;
        }

        public void EditUser(User user) {
            User u = new User(user.UserId, user.Username, user.Password, user.Name, user.Surname, user.Address, user.Phone, user.RoleId);
            userTDG.UpdateUser(u);
        }

        public User DeleteUser(User user)
        {
            int userId = user.UserId;
            User check = userTDG.FindUserById(userId);

            if (check != null)
            {
                User u2 = userTDG.DelUser(userId);
                User u1 = new User(u2.UserId,u2.Username, u2.Password, u2.Name, u2.Surname, u2.Address, u2.Phone, u2.RoleId);
                return u1;
            }
            else
            {
                return null;
            }

        }

        public int GetRoleId(string username) {
            int roleid = userTDG.GetRoleIdByUsername(username);
            return roleid;
        }

        public int getUserId(string username) {
            return userTDG.GetUserIdByUsername(username);
        }

    }
}
