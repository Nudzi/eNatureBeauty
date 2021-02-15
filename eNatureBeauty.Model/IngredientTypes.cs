using System;
using System.Collections.Generic;

namespace eNatureBeauty.Model
{
    public class IngredientTypes
    {
        public IngredientTypes(string Name)
        {
            this.Name = Name;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
