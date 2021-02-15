using System;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Database
{
    public partial class Units
    {
        public Units()
        {
            Ingredients = new HashSet<Ingredients>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ingredients> Ingredients { get; set; }
    }
}
