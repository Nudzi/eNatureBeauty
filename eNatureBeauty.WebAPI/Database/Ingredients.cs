using System;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Database
{
    public partial class Ingredients
    {
        public Ingredients()
        {
            IngredientsIngredientTypes = new HashSet<IngredientsIngredientTypes>();
            ProductIngredients = new HashSet<ProductIngredients>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitId { get; set; }
        public bool? Status { get; set; }

        public virtual Units Unit { get; set; }
        public virtual ICollection<IngredientsIngredientTypes> IngredientsIngredientTypes { get; set; }
        public virtual ICollection<ProductIngredients> ProductIngredients { get; set; }
    }
}
