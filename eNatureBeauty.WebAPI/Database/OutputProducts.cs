using System;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Database
{
    public partial class OutputProducts
    {
        public int Id { get; set; }
        public int OutputId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public virtual Outputs Output { get; set; }
        public virtual Products Product { get; set; }
    }
}
