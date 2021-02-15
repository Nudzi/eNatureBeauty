using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eNatureBeauty.Model.Requests
{
    public class ProductsUpsertRequest //same here
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
    }
}
