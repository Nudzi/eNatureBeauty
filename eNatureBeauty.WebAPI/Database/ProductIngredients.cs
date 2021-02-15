using System;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Database
{
    public partial class ProductIngredients
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public int ProductId { get; set; }
        public int Measure { get; set; }

        public virtual Ingredients Ingredient { get; set; }
        public virtual Products Product { get; set; }
    }
}
