using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eNatureBeauty.Model.Requests
{
    public class ReviewsSearchRequest //same here
    {
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
    }
}
