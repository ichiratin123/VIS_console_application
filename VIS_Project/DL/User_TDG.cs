using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;
using System.Numerics;

namespace DL
{
    public class User_TDG
    {

        public User_TDG() { }

        public void CreateUser(User user) {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = "INSERT INTO [User] (Username, Password, Name, Surname, Address, PhoneNumber, RoleId) " +
                               "VALUES (@Username, @Password, @Name, @Surname, @Address, @PhoneNumber, @RoleId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Surname", user.Surname);
                    command.Parameters.AddWithValue("@Address", user.Address);
                    command.Parameters.AddWithValue("@PhoneNumber", user.Phone);
                    command.Parameters.AddWithValue("@RoleId", user.RoleId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }

        public bool UserExists(string username)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = "SELECT COUNT(1) FROM [User] WHERE Username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        public bool checkLogin(string username, string password) {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = "SELECT COUNT(1) FROM [User] WHERE Username = @Username AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }

        }

        public User FindUser(string username, string password)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = "SELECT * FROM [User] WHERE Username = @Username AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            int UserId = (int)reader["ID"];
                            string Username = reader["Username"].ToString();
                            string Password = reader["Password"].ToString();
                            string Name = reader["Name"].ToString();
                            string Surname = reader["Surname"].ToString();
                            string Address = reader["Address"].ToString();
                            string Phone = reader["PhoneNumber"].ToString();
                            int RoleId = (int)reader["RoleId"];
                            return new User(UserId, Username, Password, Name, Surname, Address, Phone, RoleId);
                        }
                    }
                }
            }
            return null;
        }

        public User FindUserById(int id)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = "SELECT * FROM [User] WHERE id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            int UserId = (int)reader["ID"];
                            string Username = reader["Username"].ToString();
                            string Password = reader["Password"].ToString();
                            string Name = reader["Name"].ToString();
                            string Surname = reader["Surname"].ToString();
                            string Address = reader["Address"].ToString();
                            string Phone = reader["PhoneNumber"].ToString();
                            int RoleId = (int)reader["RoleId"];
                            return new User(UserId, Username, Password, Name, Surname, Address, Phone, RoleId);
                        }
                    }
                }
            }
            return null;
        }


        public int GetUserIdByUsername(string username)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = "SELECT ID FROM [User] WHERE Username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return (int)result;
                    }
                }
            }
            return 0;
        }

        public int GetRoleIdByUsername(string username)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = "SELECT RoleId FROM [User] WHERE Username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return (int)result;
                    }
                }
            }
            return 0;
        }

        public List<User> GetAllUsers()
        {
            List<User> user = new List<User>();
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                var cmd = new SqlCommand("SELECT * FROM [User]", connection);

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int UserId = (int)reader["ID"];
                        string Username = reader["Username"].ToString();
                        string Password = reader["Password"].ToString();
                        string Name = reader["Name"].ToString();
                        string Surname = reader["Surname"].ToString();
                        string Address = reader["Address"].ToString();
                        string Phone = reader["PhoneNumber"].ToString();
                        int RoleId = (int)reader["RoleId"];
                        User u2 = new User(UserId, Username, Password, Name, Surname, Address, Phone, RoleId);
                        user.Add(u2);
                    }

                }
            }
            return user;
        }

        public void UpdatePasswordUser(User user)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = @"UPDATE [User]
                         SET Password = @Password
                         WHERE ID = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@UserId", user.UserId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateNameUser(User user)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = @"UPDATE [User]
                         SET Name = @Name
                         WHERE ID = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@UserId", user.UserId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSurameUser(User user)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = @"UPDATE [User]
                         SET Surname = @Surname
                         WHERE ID = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Surname", user.Surname);
                    command.Parameters.AddWithValue("@UserId", user.UserId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateAddressUser(User user)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = @"UPDATE [User]
                         SET Address = @Address
                         WHERE ID = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Address", user.Address);
                    command.Parameters.AddWithValue("@UserId", user.UserId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePhoneUser(User user)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = @"UPDATE [User]
                         SET PhoneNumber = @PhoneNumber
                         WHERE ID = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PhoneNumber", user.Phone);
                    command.Parameters.AddWithValue("@UserId", user.UserId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateRoleUser(User user)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = @"UPDATE [User]
                         SET RoleId = @RoleId
                         WHERE ID = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoleId", user.RoleId);
                    command.Parameters.AddWithValue("@UserId", user.UserId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUser(User user)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = @"UPDATE [User]
                         SET Password = @Password,
                             Name = @Name,
                             Surname = @Surname,
                             Address = @Address,
                             PhoneNumber = @PhoneNumber,
                             RoleId = @RoleId
                         WHERE ID = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Surname", user.Surname);
                    command.Parameters.AddWithValue("@Address", user.Address);
                    command.Parameters.AddWithValue("@PhoneNumber", user.Phone);
                    command.Parameters.AddWithValue("@RoleId", user.RoleId);
                    command.Parameters.AddWithValue("@UserId", user.UserId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public User DelUser(int cusid)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {

                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [user] WHERE ID = @cusid;", connection);
                cmd.Parameters.AddWithValue("@cusid", cusid);

                User u2 = null;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int UserId = (int)reader["ID"];
                        string Username = reader["Username"].ToString();
                        string Password = reader["Password"].ToString();
                        string Name = reader["Name"].ToString();
                        string Surname = reader["Surname"].ToString();
                        string Address = reader["Address"].ToString();
                        string Phone = reader["PhoneNumber"].ToString();
                        int RoleId = (int)reader["RoleId"];
                        u2 = new User(UserId, Username, Password, Name, Surname, Address, Phone, RoleId);
                    }
                }
                if (u2 != null)
                {
                    var deleteCustomerCmd = new SqlCommand("DELETE FROM [user] WHERE ID = @cusid", connection);
                    deleteCustomerCmd.Parameters.AddWithValue("@cusid", cusid);
                    deleteCustomerCmd.ExecuteNonQuery();
                }

                return u2;
            }
        }
    }
}
