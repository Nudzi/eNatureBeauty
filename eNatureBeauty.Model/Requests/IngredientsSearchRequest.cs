using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eNatureBeauty.Model.Requests
{
    public class IngredientsSearchRequest
    {
        public int? IngredientTypeID { get; set; }
        public int? IngredientID { get; set; }
        public string Name { get; set; }
    }
}
