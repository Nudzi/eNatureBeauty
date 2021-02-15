using System;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Database
{
    public partial class Storages
    {
        public Storages()
        {
            Inputs = new HashSet<Inputs>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Inputs> Inputs { get; set; }
    }
}
