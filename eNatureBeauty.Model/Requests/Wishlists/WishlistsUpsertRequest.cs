using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eNatureBeauty.Model.Requests
{
    public class WishlistsUpsertRequest //same here
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
    }
}
