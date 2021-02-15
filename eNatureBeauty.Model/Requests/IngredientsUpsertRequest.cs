using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eNatureBeauty.Model.Requests
{
    public class IngredientsUpsertRequest //same here
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitID { get; set; }
        public bool? Status { get; set; }
        public List<int> IngredientsTypes { get; set; } = new List<int>();
    }
}
