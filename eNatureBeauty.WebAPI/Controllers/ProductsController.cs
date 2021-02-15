using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Services;

namespace eNatureBeauty.WebAPI.Controllers
{
    public class ProductsController : BaseCRUDController<Model.Products, ProductsSearchRequest, ProductsUpsertRequest, ProductsUpsertRequest>
    {
        public ProductsController(ICRUDService<Model.Products, ProductsSearchRequest, ProductsUpsertRequest, ProductsUpsertRequest> service) : base(service)
        {

        }
    }
}
