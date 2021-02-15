using eNatureBeauty.WebAPI.Services;

namespace eNatureBeauty.WebAPI.Controllers
{
    public class UnitsController : BaseController<Model.Units, object>
    {
        public UnitsController(IService<Model.Units, object> service) : base(service)
        {

        }
    }
}
