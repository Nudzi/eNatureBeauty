using System;
using System.Collections.Generic;
using System.Text;

namespace eNatureBeauty.Model.Requests.ProductsIngredients
{
    public class ProductsIngredientsUpsertRequest
    {
        public int Id { get; set; }
        public int IngredientID { get; set; }
        public int ProductID { get; set; }
        public int Measure { get; set; }
    }
}
