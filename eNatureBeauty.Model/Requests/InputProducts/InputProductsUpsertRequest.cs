using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNatureBeauty.Model.Requests.InputProducts
{
    public class InputProductsUpsertRequest
    {
        public int Id { get; set; }
        public int InputId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        //public Model.Inputs Input { get; set; } = new Model.Inputs();
        //public Model.Products Product { get; set; } = new Model.Products();
    }
}
