using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ProductDTO(int productId, string name, string description, decimal price, int quantity, int categoryId, string categoryName)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            CategoryId = categoryId;
            CategoryName = categoryName;
        }
        public ProductDTO(string name, string description, decimal price, int quantity, string categoryName)
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            CategoryName = categoryName;
        }

        public ProductDTO(int productId, string name)
        {
            ProductId = productId;
            Name = name;
        }
    }
}
