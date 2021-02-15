using eNatureBeauty.WebAPI.Services;

namespace eNatureBeauty.WebAPI.Controllers
{
    public class IngredientTypesController : BaseController<Model.IngredientTypes, object>
    {
        public IngredientTypesController(IService<Model.IngredientTypes, object> service) : base(service)
        {

        }
    }
}
