using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductSingleton
    {
        private static ProductSingleton _instance;
        public List<ProductDTO> products { get; private set; }
        private ProductSingleton()
        {
            products = new List<ProductDTO>();
        }
        public static ProductSingleton getInstance()
        {
            if (_instance == null)
            {
                _instance = new ProductSingleton();
            }
            return _instance;
        }
        public void UpdateProduct(ProductDTO updateProduct)
        {
            foreach (var product in products)
            {
                if (product.ProductId == updateProduct.ProductId) {
                    product.Name = updateProduct.Name;
                    product.Description = updateProduct.Description;
                    product.Price = updateProduct.Price;
                    product.Quantity = updateProduct.Quantity;
                    product.CategoryId = updateProduct.CategoryId;
                    product.CategoryName = updateProduct.CategoryName;
                    break;
                }
            }
        }

        public void LoadProduct()
        {
            BLProduct blProduct = new BLProduct();
            products = blProduct.GetAllProduct ();
        }
    }
}
