using eNatureBeauty.Model.Requests.Outputs;
using eNatureBeauty.WebAPI.Services;

namespace eNatureBeauty.WebAPI.Controllers
{
    public class OutputsController : BaseCRUDController<Model.Outputs, OutputsSearchRequest, OutputsUpsertRequest, OutputsUpsertRequest>
    {
        public OutputsController(ICRUDService<Model.Outputs, OutputsSearchRequest, OutputsUpsertRequest, OutputsUpsertRequest> service) : base(service)
        {

        }
    }
}