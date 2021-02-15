using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNatureBeauty.Model.Requests.Orders
{
    public class OrdersSearchRequest
    {
        public string OrderNumber { get; set; }
        public int? UserId { get; set; }
    }
}
