using BL;
using DL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLOrder
    {
        private Order_TDG orderTDG = new Order_TDG();
        public void addOrder(OrderDTO order) {
            int orderid = order.id;
            int userid = order.userId;
            DateTime date = order.date;
            decimal price = order.totalAmount;
            string ordernumber = order.orderNumber;
            OrderDTO o = new OrderDTO(orderid, userid, date, price, ordernumber);
            orderTDG.AddOrder(o);
        }

        public string generateOrderNumber(int userid, int productid, DateTime date) {
            string id = userid.ToString();
            string pid = productid.ToString();
            string datetime = date.ToString("yyyyMMddHHmmss");
            string ordernumber = $"{id}{pid}{datetime}";
            return ordernumber ;
        }

        public int getOrderid(string Ordernumber) {
            return orderTDG.getOrderId(Ordernumber);
        }

        public List<OrderDTO> GetAllOrder() {
            return orderTDG.GetAllOrder();
        }
    }
}
