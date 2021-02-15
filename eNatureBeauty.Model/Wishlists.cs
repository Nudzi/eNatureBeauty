using System;
using System.Collections.Generic;
using System.Text;

namespace eNatureBeauty.Model
{
    public class Wishlists
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
    }
}
