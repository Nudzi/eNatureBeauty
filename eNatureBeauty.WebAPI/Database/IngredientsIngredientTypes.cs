using System;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Database
{
    public partial class IngredientsIngredientTypes
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public int IngredientTypeId { get; set; }
        public string Description { get; set; }

        public virtual Ingredients Ingredient { get; set; }
        public virtual IngredientTypes IngredientType { get; set; }
    }
}
