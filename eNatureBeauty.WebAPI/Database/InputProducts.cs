using System;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Database
{
    public partial class InputProducts
    {
        public int Id { get; set; }
        public int InputId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual Inputs Input { get; set; }
        public virtual Products Product { get; set; }
    }
}
