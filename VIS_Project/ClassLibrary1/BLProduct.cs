using DL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLProduct
    {
        private Product_TDG productTDG = new Product_TDG();
        public BLProduct() { }

        public int createProduct(ProductDTO product)
        {
            string name = product.Name;
            int id = productTDG.GetIdByName(name);
            if (productTDG.ItemExists(name))
            {
                return -1;
            }
            else
            {
                string description = product.Description;
                decimal price = product.Price;
                int quantity = product.Quantity;
                string categoryname = product.CategoryName;
                int categoryid = productTDG.GetIdCateByName(categoryname);
                ProductDTO product2 = new ProductDTO(id, name, description, price, quantity, categoryid, categoryname);
                productTDG.AddProduct(product2);
                return 0;
            }
        }

        public List<ProductDTO> GetAllProduct()
        {
            List<ProductDTO> p1 = productTDG.GetAllProduct();
            List<ProductDTO> p2 = new List<ProductDTO>();
            foreach (ProductDTO i in p1)
            {
                ProductDTO product = new ProductDTO(i.ProductId, i.Name, i.Description, i.Price, i.Quantity, i.CategoryId, i.CategoryName);
                p2.Add(product);
            }
            return p2;
        }

        public void EditProduct(ProductDTO product)
        {
            ProductDTO p = new ProductDTO(product.ProductId, product.Name, product.Description, product.Price, product.Quantity, product.CategoryId, product.CategoryName);
            productTDG.updateProduct(p);

        }

        public int getIdbyName(string name)
        {

            int id = productTDG.GetIdByName(name);
            return id;

        }

        public int getProductIdByCategory(string categoryname)
        {
            int id = productTDG.GetIdCateByName(categoryname);
            return id;
        }

        public List<ProductDTO> getProductList()
        {
            return productTDG.getProductList();
        }

        public ProductDTO getProduct(int id) {
            return productTDG.getProductById(id);
        }

        public decimal getPricebyID(int id) {
            return productTDG.getPrice(id);
        }

        public int getQuantityById(int id) {
            return productTDG.getQuantity(id);
        }

        public int quantityDecrease(int id) {
            int minus = getQuantityById(id) - 1;
            if (minus < 0)
            {
                return -1;
            }
            else {
                productTDG.updateProductQuantity(minus, id);
                int quantity = productTDG.getQuantity(id);
                return quantity;
            }
        }

        public string getProductName(int id)
        {
            return productTDG.getProductName(id);
        }
    }
}
