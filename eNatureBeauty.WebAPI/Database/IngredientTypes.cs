using System;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Database
{
    public partial class IngredientTypes
    {
        public IngredientTypes()
        {
            IngredientsIngredientTypes = new HashSet<IngredientsIngredientTypes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<IngredientsIngredientTypes> IngredientsIngredientTypes { get; set; }
    }
}
