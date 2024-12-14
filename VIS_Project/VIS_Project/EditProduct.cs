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
    public partial class EditProduct : Form
    {
        private ProductDTO productEdit;
        BLProduct blproduct = new BLProduct();
        public EditProduct(ProductDTO product)
        {
            InitializeComponent();
            productEdit = product;
        }

        private void EditProduct_Load(object sender, EventArgs e)
        {
            idTB.Text = productEdit.ProductId.ToString();
            nameTB.Text = productEdit.Name.ToString();
            desTB.Text = productEdit.Description.ToString();
            priceTB.Text = productEdit.Price.ToString();
            quanntityTB.Text = productEdit.Quantity.ToString();
            _ = productEdit.CategoryId == 1 ? sungBT.Checked = true : glsBT.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            idTB.Text = productEdit.ProductId.ToString();
            int id = int.Parse(idTB.Text);
            string name = nameTB.Text;
            string des = desTB.Text;
            decimal price = decimal.Parse(priceTB.Text);
            int quan = int.Parse(quanntityTB.Text);
            string cateName = "";
            int cateid = 1;
            if (sungBT.Checked == true)
            {
                sungBT.Checked = true;
                cateName = sungBT.Text;
            }
            else
            {
                glsBT.Checked = true;
                cateName = glsBT.Text;
                cateid = 2;

            }
            if (nameTB.Text == null || desTB.Text == null || priceTB.Text == null || priceTB.Text == null)
            {
                MessageBox.Show("Must fill all detail");
            }
            else
            {
                ProductDTO product = new ProductDTO(id, name, des, price, quan, cateid, cateName);
                ProductSingleton.getInstance().UpdateProduct(product);
                blproduct.EditProduct(product);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Cancel Edit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }

        }
    }
}
