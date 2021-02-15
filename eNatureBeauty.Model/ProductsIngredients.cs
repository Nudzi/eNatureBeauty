using System;
using System.Collections.Generic;

namespace eNatureBeauty.Model
{
    public class ProductsIngredients
    {
        public int Id { get; set; }
        public int IngredientID { get; set; }
        public int ProductID { get; set; }
        public int Measure { get; set; }
    }
}
