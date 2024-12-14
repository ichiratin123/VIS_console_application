using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class ReviewDTO
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int UserId { get; set; }
        public string comment { get; set; }
        public DateTime date { get; set; }

        public ReviewDTO(int id, int productId, int userId, string comment, DateTime date)
        {
            this.id = id;
            this.productId = productId;
            UserId = userId;
            this.comment = comment;
            this.date = date;
        }
    }
}
