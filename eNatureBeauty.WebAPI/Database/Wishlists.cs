using System;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Database
{
    public partial class Wishlists
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }

        public virtual Products Product { get; set; }
        public virtual Users User { get; set; }
    }
}
