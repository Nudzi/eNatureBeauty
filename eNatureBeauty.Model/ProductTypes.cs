using System;
using System.Collections.Generic;

namespace eNatureBeauty.Model
{
    public class ProductTypes
    {
        public ProductTypes(string name = "")
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
