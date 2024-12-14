using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DL
{
    public class Product_TDG
    {
        public Product_TDG() { }

        public void AddProduct(ProductDTO product)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = "INSERT INTO Product (name, description, price, categoryid, quantity) " +
                               "VALUES (@name, @description, @price, @categoryid, @quantity)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@description", product.Description);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@categoryid", product.CategoryId);
                    command.Parameters.AddWithValue("@quantity", product.Quantity);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }

        public bool ItemExists(string name)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = "SELECT COUNT(1) FROM Product WHERE name = @name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        public ProductDTO FindItem(string name)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query =  @"
                    SELECT 
                        p.ProductId, 
                        p.Name AS ProductName, 
                        p.Description, 
                        p.Price, 
                        p.Quantity, 
                        p.CategoryId, 
                        c.Name AS CategoryName
                    FROM Product p
                    INNER JOIN Category c ON p.CategoryId = c.CategoryID
                    WHERE p.Name = @name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            int ProductId = (int)reader["ProductId"];
                            string Itemname = reader["name"].ToString();
                            string description = reader["Description"].ToString();
                            decimal price = (decimal)reader["Price"];
                            int categoryId = (int)reader["CategoryId"];
                            string catename = reader["CategoryName"].ToString();
                            int quantity = (int)reader["Quantity"];
                            return new ProductDTO(ProductId, Itemname, description, price, quantity, categoryId, catename);
                        }
                    }
                }
            }
            return null;
        }

        public int GetIdByName(string name)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = "SELECT ProductID FROM Product WHERE name = @name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
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

        public int GetIdCateByName(string cate)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = "SELECT CategoryID FROM Category WHERE name = @cate";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cate", cate);
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

        public string GetNameByIdCate(int id)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = "SELECT name FROM Category WHERE CategoryID = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString();
                    }
                }
            }
            return "";
        }

        public List<ProductDTO> GetAllProduct()
        {
            List<ProductDTO> productList = new List<ProductDTO>();
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = @"
                    SELECT 
                        p.ProductID,
                        p.Name,
                        p.Description,
                        p.Price,
                        p.Quantity,
                        p.CategoryID,
                        c.Name AS CategoryName
                    FROM 
                        Product p
                    INNER JOIN 
                        Category c ON p.CategoryID = c.CategoryID";

                var cmd = new SqlCommand(query, connection);

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int productID = (int)reader["ProductID"];
                        string name = reader["Name"].ToString();
                        string description = reader["Description"].ToString();
                        decimal price = (decimal)reader["Price"];
                        int cateID = (int)reader["CategoryID"];
                        int quantity = (int)reader["Quantity"];
                        string cateName = reader["CategoryName"].ToString();

                        ProductDTO p = new ProductDTO(productID, name, description, price, quantity, cateID, cateName);
                        productList.Add(p);
                    }
                }
            }
            return productList;
        }

        public void updateProduct(ProductDTO product)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = @"UPDATE Product
                         SET Name = @name,
                             Description = @des,
                             Price = @price,
                             Quantity = @quantity,
                             CategoryID = @cateid
                         WHERE productID = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@des", product.Description);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@quantity", product.Quantity);
                    command.Parameters.AddWithValue("@cateid", product.CategoryId);
                    command.Parameters.AddWithValue("@id", product.ProductId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ProductDTO> getProductList() {
            List<ProductDTO> productList = new List<ProductDTO>();
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = "SELECT ProductID, Name FROM Product";
                var cmd = new SqlCommand(query, connection);

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int productID = (int)reader["ProductID"];
                        string name = reader["Name"].ToString();

                        ProductDTO p = new ProductDTO(productID, name);
                        productList.Add(p);
                    }
                }
            }
            return productList;
                
        }

        public ProductDTO getProductById(int id) {
            ProductDTO product = null;
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = @"
                    SELECT 
                        p.ProductID,
                        p.Name,
                        p.Description,
                        p.Price,
                        p.Quantity,
                        p.CategoryID,
                        c.Name AS CategoryName
                    FROM 
                        Product p
                    INNER JOIN 
                        Category c ON p.CategoryID = c.CategoryID
                    WHERE 
                        p.ProductID = @ProductID";

                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductID", id);

                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int pid = (int)reader["ProductID"];
                        string name = reader["Name"].ToString();
                        string description = reader["Description"].ToString();
                        decimal price = (decimal)reader["Price"];
                        int cateID = (int)reader["CategoryID"];
                        int quantity = (int)reader["Quantity"];
                        string cateName = reader["CategoryName"].ToString();
                        product = new ProductDTO(id, name, description, price, quantity, cateID, cateName);
                    }
                }
            }

            return product;
        }

        public decimal getPrice(int id) {
            decimal price = 0;
            string query = "SELECT Price FROM Product WHERE ProductID = @ProductID";
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", id);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    price = Convert.ToDecimal(result);
                }
            }

            return price;
        }

        public int getQuantity(int id)
        {
            int quantity = 0;
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = "SELECT quantity FROM product WHERE productid = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        quantity = (int)result;
                    }
                }
            }
            return quantity;
        }

        public string getProductName(int id)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = "SELECT Name FROM product WHERE productid = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString();
                    }
                }
            }
            return "";
        }
        public void updateProductQuantity(int quantity, int id)
        {
            using (SqlConnection connection = DataBaseSingleTon.getInstance().GetConnection())
            {
                string query = @"UPDATE Product
                         SET Quantity = @quantity
                         WHERE productID = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}
