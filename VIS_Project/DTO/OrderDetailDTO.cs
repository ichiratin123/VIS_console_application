using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDetailDTO
    {
        public int id { get; set; }
        public int orderid{ get; set; }
        public int productid { get; set; }
        public int userid { get; set; }
        public string productName { get; set; }
        public decimal subtotal { get; set; }

        public OrderDetailDTO(int id, int orderid, int productid, int userid, string productName, decimal subtotal)
        {
            this.id = id;
            this.orderid = orderid;
            this.productid = productid;
            this.userid = userid;
            this.productName = productName;
            this.subtotal = subtotal;
        }
        public OrderDetailDTO(int orderid, int productid, int userid, string productName, decimal subtotal)
        {
            this.id = id;
            this.orderid = orderid;
            this.productid = productid;
            this.userid = userid;
            this.productName = productName;
            this.subtotal = subtotal;
        }
    }
}

