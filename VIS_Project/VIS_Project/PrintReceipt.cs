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
    public partial class PrintReceipt : Form
    {
        private OrderDetailDTO odv;
        OrderDetailBL odBL = new OrderDetailBL();
        public PrintReceipt(OrderDetailDTO od)
        {
            InitializeComponent();
            odv = od;
        }

        private void PrintReceipt_Load(object sender, EventArgs e)
        {
            orderidLB.Text = odv.orderid.ToString();
            nameLB.Text = odv.productName.ToString();
            priceLB.Text = odv.subtotal.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Print success");
            this.Close();
        }
    }
}
