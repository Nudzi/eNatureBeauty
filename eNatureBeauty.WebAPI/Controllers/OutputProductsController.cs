using eNatureBeauty.Model.Requests.OutputProducts;
using eNatureBeauty.WebAPI.Services;

namespace eNatureBeauty.WebAPI.Controllers
{
    public class OutputProductsController : BaseCRUDController<Model.OutputProducts, OutputProductsSearchRequest, OutputProductsUpsertRequest, OutputProductsUpsertRequest>
    {
        public OutputProductsController(ICRUDService<Model.OutputProducts, OutputProductsSearchRequest, OutputProductsUpsertRequest, OutputProductsUpsertRequest> service) : base(service)
        {

        }
    }
}
