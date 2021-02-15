using System;
using System.Collections.Generic;

namespace eNatureBeauty.Model
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int ProductTypeId { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public byte[] ImageThumb { get; set; }
        public bool? Status { get; set; }
        public ICollection<OutputProducts> OutputProducts { get; set; }
    }
}
