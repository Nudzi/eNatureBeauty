using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNatureBeauty.Model
{
    public class Orders
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public bool? Cancel { get; set; }

        //public Users User { get; set; }
    }
}
