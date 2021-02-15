using System;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Database
{
    public partial class Products
    {
        public Products()
        {
            InputProducts = new HashSet<InputProducts>();
            OutputProducts = new HashSet<OutputProducts>();
            ProductIngredients = new HashSet<ProductIngredients>();
            Reviews = new HashSet<Reviews>();
            Wishlists = new HashSet<Wishlists>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int ProductTypeId { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public byte[] ImageThumb { get; set; }
        public bool? Status { get; set; }

        public virtual ProductTypes ProductType { get; set; }
        public virtual ICollection<InputProducts> InputProducts { get; set; }
        public virtual ICollection<OutputProducts> OutputProducts { get; set; }
        public virtual ICollection<ProductIngredients> ProductIngredients { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
        public virtual ICollection<Wishlists> Wishlists { get; set; }
    }
}
