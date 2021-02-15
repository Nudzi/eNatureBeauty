using System;
using System.Collections.Generic;

namespace eNatureBeauty.Model
{
    public class Ingredients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitID { get; set; }
        public bool? Status { get; set; }
        public List<IngredientsIngredientTypes> IngredientsTypes { get; set; }
    }
}
