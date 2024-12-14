using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BL
{
    public class UserSingleton
    {
        private static UserSingleton _instance;
        public List<User> Users { get; private set; }
        private UserSingleton()
        {
            Users = new List<User>();
        }
        public static UserSingleton getInstance()
        {
            if (_instance == null)
            {
                _instance = new UserSingleton();
            }
            return _instance;
        }
        public void UpdateUser(User updatedUser)
        {
            foreach (var user in Users)
            {
                if (user.UserId == updatedUser.UserId)
                {
                    user.Username = updatedUser.Username;
                    user.Password = updatedUser.Password;
                    user.Name = updatedUser.Name;
                    user.Surname = updatedUser.Surname;
                    user.Address = updatedUser.Address;
                    user.Phone = updatedUser.Phone;
                    user.RoleId = updatedUser.RoleId;
                    break;
                }
            }
        }

        public void LoadUsers()
        {
            BLUser blUser = new BLUser();
            Users = blUser.GetAllUser();
        }
    }
}
