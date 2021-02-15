using eNatureBeauty.WebAPI.Services;

namespace eNatureBeauty.WebAPI.Controllers
{
    public class ProductTypesController : BaseController<Model.ProductTypes, object>
    {
        public ProductTypesController(IService<Model.ProductTypes, object> service) : base(service)
        {

        }
    }
}
