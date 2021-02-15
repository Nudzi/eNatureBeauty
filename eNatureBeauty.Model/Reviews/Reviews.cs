using System;
using System.Collections.Generic;
using System.Text;

namespace eNatureBeauty.Model.Reviews
{
    public class Reviews
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Review { get; set; }
        public string Description { get; set; }
    }
}
