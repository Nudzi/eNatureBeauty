using eNatureBeauty.Model.Requests.Inputs;
using eNatureBeauty.WebAPI.Services;

namespace eNatureBeauty.WebAPI.Controllers
{
    public class InputsController : BaseCRUDController<Model.Inputs, InputsSearchRequest, InputsUpsertRequest, InputsUpsertRequest>
    {
        public InputsController(ICRUDService<Model.Inputs, InputsSearchRequest, InputsUpsertRequest, InputsUpsertRequest> service) : base(service)
        {

        }
    }
}