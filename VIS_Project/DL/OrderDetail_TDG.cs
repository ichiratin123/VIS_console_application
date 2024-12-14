using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class OrderDetail_TDG
    {
        public OrderDetail_TDG() { }

        public void addOrderDetail(OrderDetailDTO od)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = "INSERT INTO OrderDetail (OrderID, ProductID ,SubTotal, ProductName ,UserID) " +
                       "VALUES (@orderid, @productid, @subtotal, @productName ,@userid)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@orderid", od.orderid);
                    command.Parameters.AddWithValue("@productid", od.productid);
                    command.Parameters.AddWithValue("@subtotal", od.subtotal);
                    command.Parameters.AddWithValue("@productName", od.productName);
                    command.Parameters.AddWithValue("@userid", od.userid);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<OrderDetailDTO> GetAllOrders()
        {
            List<OrderDetailDTO> odList = new List<OrderDetailDTO>();
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = @"
                   SELECT 
                        OD.OrderDetailID,
                        OD.OrderID,
                        O.UserID,
                        OD.ProductID,
                        P.Name AS ProductName,
                        OD.SubTotal
                    FROM 
                        OrderDetail OD
                    INNER JOIN [Order] O ON OD.OrderID = O.OrderID
                    INNER JOIN Product P ON OD.ProductID = P.ProductID;";

                var cmd = new SqlCommand(query, connection);

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int orderDetailID = (int)reader["OrderDetailID"];
                        int orderID = (int)reader["OrderID"];
                        int userID = (int)reader["UserID"];
                        int productID = (int)reader["ProductID"];
                        string productName = reader["ProductName"].ToString();
                        decimal subTotal = (decimal)reader["SubTotal"];
                        OrderDetailDTO od = new OrderDetailDTO(orderDetailID, orderID, productID,userID, productName, subTotal);
                        odList.Add(od);
                    }
                }
            }
            return odList;
        }
    }
}
