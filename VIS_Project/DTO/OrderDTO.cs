using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class OrderDTO
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DateTime date { get; set; }
        public decimal totalAmount { get; set; }
        public string orderNumber { get; set; }

        public OrderDTO(int id, int userId, DateTime date, decimal totalAmount, string orderNumber)
        {
            this.id = id;
            this.userId = userId;
            this.date = date;
            this.totalAmount = totalAmount;
            this.orderNumber = orderNumber;
        }

        public OrderDTO(int userId, DateTime date, decimal totalAmount, string orderNumber)
        {
            this.userId = userId;
            this.date = date;
            this.totalAmount = totalAmount;
            this.orderNumber = orderNumber;
        }
    }
}
