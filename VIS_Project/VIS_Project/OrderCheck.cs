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
using BL;
using DL;

namespace VIS_Project
{
    public partial class OrderCheck : Form
    {
        BLOrder blorder = new BLOrder();
        OrderDetailBL odbl = new OrderDetailBL();
        public OrderCheck()
        {
            InitializeComponent();
        }

        private void OrderCheck_Load(object sender, EventArgs e)
        {
            List<OrderDetailDTO> odList = odbl.GetAllDetail();
            listView1.View = View.Details;
            listView1.Columns.Add("Order Detail ID", 100);
            listView1.Columns.Add("Order ID", 100);
            listView1.Columns.Add("User ID", 100);
            listView1.Columns.Add("Product ID", 100);
            listView1.Columns.Add("Product Name", 150);
            listView1.Columns.Add("SubTotal", 150);
            listView1.Items.Clear();
            foreach (OrderDetailDTO od in odList)
            {
                var item = new ListViewItem(od.id.ToString());
                item.SubItems.Add(od.orderid.ToString());
                item.SubItems.Add(od.userid.ToString());
                item.SubItems.Add(od.productid.ToString());
                item.SubItems.Add(od.productName.ToString());
                item.SubItems.Add(od.subtotal.ToString());

                listView1.Items.Add(item);
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                var selectedItem = listView1.SelectedItems[0];
                string orderDetailIdStr = selectedItem.SubItems[0].Text;
                string orderIdStr = selectedItem.SubItems[1].Text;   
                string userIdStr = selectedItem.SubItems[2].Text; 
                string productIdStr = selectedItem.SubItems[3].Text;
                string productName = selectedItem.SubItems[4].Text;
                string subTotalStr = selectedItem.SubItems[5].Text;
                int orderDetailId = int.Parse(orderDetailIdStr);
                int orderId = int.Parse(orderIdStr);
                int userId = int.Parse(userIdStr);
                int productId = int.Parse(productIdStr);
                decimal subTotal = decimal.Parse(subTotalStr);
                OrderDetailDTO od = new OrderDetailDTO(orderDetailId, orderId, userId, productId, productName, subTotal);
                PrintReceipt form = new PrintReceipt(od);
                form.ShowDialog();
            }
        }
    }
}
