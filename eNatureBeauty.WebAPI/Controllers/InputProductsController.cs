using eNatureBeauty.Model.Requests.InputProducts;
using eNatureBeauty.Model.Requests.Inputs;
using eNatureBeauty.WebAPI.Services;

namespace eNatureBeauty.WebAPI.Controllers
{
    public class InputProductsController : BaseCRUDController<Model.InputProducts, InputProductsSearchRequest, InputProductsUpsertRequest, InputProductsUpsertRequest>
    {
        public InputProductsController(ICRUDService<Model.InputProducts, InputProductsSearchRequest, InputProductsUpsertRequest, InputProductsUpsertRequest> service) : base(service)
        {

        }
    }
}
