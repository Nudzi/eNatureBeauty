using System;
using System.Collections.Generic;
using System.Text;

namespace eNatureBeauty.Model.Requests.ProductsIngredients
{
    public class ProductIngredientAdd
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public int IngredientId { get; set; }
        public int Measure { get; set; } = 0;
    }
}
