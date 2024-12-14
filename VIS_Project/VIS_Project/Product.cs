using BL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIS_Project
{
    public partial class Product : Form
    {
        BLProduct blpro = new BLProduct();
        public Product()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            List<ProductDTO> product = blpro.GetAllProduct();
            listView1.View = View.Details;
            listView1.Columns.Add("Product ID", 100);
            listView1.Columns.Add("Name", 150);
            listView1.Columns.Add("Description", 400);
            listView1.Columns.Add("Price", 200);
            listView1.Columns.Add("Quantity", 200);
            listView1.Columns.Add("Category ID", 200);
            listView1.Columns.Add("Category Name", 200);
            listView1.Items.Clear();
            foreach (ProductDTO p1 in product)
            {
                var item = new ListViewItem(p1.ProductId.ToString());
                item.SubItems.Add(p1.Name);
                item.SubItems.Add(p1.Description);
                item.SubItems.Add(p1.Price.ToString());
                item.SubItems.Add(p1.Quantity.ToString());
                item.SubItems.Add(p1.CategoryId.ToString());
                item.SubItems.Add(p1.CategoryName);
                listView1.Items.Add(item);
            }

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddProduct form = new AddProduct();
            form.ShowDialog();
            ReloadData();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                var selectedItem = listView1.SelectedItems[0];
                string productid = selectedItem.SubItems[0].Text;
                int id = Int32.Parse(productid);
                string name = selectedItem.SubItems[1].Text;
                string description = selectedItem.SubItems[2].Text;
                string price = selectedItem.SubItems[3].Text;
                decimal priceP = decimal.Parse(price);
                string quantity = selectedItem.SubItems[4].Text;
                int quan = Int32.Parse(quantity);
                string cateID = selectedItem.SubItems[5].Text;
                int cateid = Int32.Parse(cateID);
                string cateName = selectedItem.SubItems[6].Text;
                ProductDTO product = new ProductDTO(id, name, description, priceP, quan, cateid, cateName);
                EditProduct form = new EditProduct(product);
                form.ShowDialog();
            }
            ReloadData();
        }

        private void ReloadData()
        {
            ProductSingleton.getInstance().LoadProduct();
            listView1.Items.Clear();

            foreach (var p1 in ProductSingleton.getInstance().products)
            {
                var item = new ListViewItem(p1.ProductId.ToString());
                item.SubItems.Add(p1.Name);
                item.SubItems.Add(p1.Description);
                item.SubItems.Add(p1.Price.ToString());
                item.SubItems.Add(p1.Quantity.ToString());
                item.SubItems.Add(p1.CategoryId.ToString());
                item.SubItems.Add(p1.CategoryName);
                listView1.Items.Add(item);
            }
        }
    }
}
