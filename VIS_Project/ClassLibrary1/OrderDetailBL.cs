using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BL
{
    public class OrderDetailBL
    {
        private OrderDetail_TDG odTDG = new OrderDetail_TDG();
        public OrderDetailBL() { }
        public void addOrderDetail(OrderDetailDTO od) {
            int id = od.id;
            int orderid = od.orderid;
            int productid = od.productid;
            int userid = od.userid;
            string productName = od.productName;
            decimal price = od.subtotal;
            OrderDetailDTO o = new OrderDetailDTO(id, orderid, productid,userid,productName, price);
            odTDG.addOrderDetail(o);
        }

        public List<OrderDetailDTO> GetAllDetail()
        {
            List<OrderDetailDTO> o1 = odTDG.GetAllOrders();
            List<OrderDetailDTO> o2 = new List<OrderDetailDTO>();
            foreach (OrderDetailDTO i in o1)
            {
                OrderDetailDTO o = new OrderDetailDTO(i.id, i.orderid, i.productid, i.userid, i.productName, i.subtotal);
                o2.Add(o);
            }
            return o2;
        }
    }
}
