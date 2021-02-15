using System;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Database
{
    public partial class Orders
    {
        public Orders()
        {
            Outputs = new HashSet<Outputs>();
        }

        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public bool? Cancel { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Outputs> Outputs { get; set; }
    }
}
