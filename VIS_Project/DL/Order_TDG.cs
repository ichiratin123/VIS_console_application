using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Order_TDG
    {
        public Order_TDG() { }
        public void AddOrder(OrderDTO order) {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = "INSERT INTO [Order] ( UserID, OrderDate, ToTalAmount, OrderNumber) " +
                               "VALUES ( @userid, @orderdate, @totalamount, @num)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userid", order.userId);
                    command.Parameters.AddWithValue("@orderdate", order.date);
                    command.Parameters.AddWithValue("@totalamount", order.totalAmount);
                    command.Parameters.AddWithValue("@num", order.orderNumber);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public int getOrderId(string orderNumber)
        {
            int id = 0;
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = "SELECT OrderID FROM [Order] WHERE OrderNumber = @orderNumber";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@orderNumber", orderNumber);
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

        public List<OrderDTO> GetAllOrder() {
            List<OrderDTO> oList = new List<OrderDTO>();
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection()) {
                string query = @" SELECT OrderID, UserID, OrderDate, TotalAmount, OrderNumber FROM [Order]";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int orderid = (int)reader["OrderID"];
                        int userid = (int)reader["UserID"];
                        DateTime date = (DateTime)reader["OrderDate"];
                        decimal price = (decimal)reader["TotalAmount"];
                        String number = reader["OrderNumber"].ToString();
                        OrderDTO order = new OrderDTO(orderid, userid, date, price, number);
                        oList.Add(order);
                    }
                }
            }
            return oList;
        }
    }
}
