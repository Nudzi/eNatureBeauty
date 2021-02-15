using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eNatureBeauty.Model;

namespace eNatureBeauty.Model.Requests.Orders
{
    public class OrdersUpsertRequest
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public bool? Cancel { get; set; }
    }
}
