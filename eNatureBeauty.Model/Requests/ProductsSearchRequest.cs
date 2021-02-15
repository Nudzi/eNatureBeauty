using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eNatureBeauty.Model.Requests
{
    public class ProductsSearchRequest
    {
        public int? ProductTypeId { get; set; }
        public string ProductName { get; set; }
    }
}
