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
    public partial class AddProduct : Form
    {
        BLProduct blpro = new BLProduct();
        public AddProduct()
        {
            InitializeComponent();
            priceTB.KeyPress += priceTB_KeyPress;
            quanntityTB.KeyPress += quantityTB_KeyPress;
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = nameTB.Text;
            string cate = sungBT.Checked ? "sunglasses" : "glasses";
            string description = desTB.Text;
            decimal price = decimal.Parse(priceTB.Text);
            int quantity = int.Parse(quanntityTB.Text);
            int id = blpro.getIdbyName(name);
            int cateid = blpro.getProductIdByCategory(cate);
            ProductDTO p = new ProductDTO(id, name, description, price, quantity, cateid, cate);
            if (blpro.createProduct(p) == -1)
            {
                MessageBox.Show("User product exits");
            }
            else
            {
                if (nameTB.Text == null || desTB.Text == null || priceTB.Text == null || priceTB.Text == null)
                {
                    MessageBox.Show("Must fill all detail");
                }
                ProductSingleton.getInstance().LoadProduct();
                MessageBox.Show("OK");
                this.Hide();
            }
        }

        private void priceTB_TextChanged(object sender, EventArgs e)
        {

        }
        private void priceTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                MessageBox.Show("Only price. EX: 120.23", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
                MessageBox.Show("Only price. EX: 120.23", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void quantityTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only numbers. Ex: 1 2 3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
