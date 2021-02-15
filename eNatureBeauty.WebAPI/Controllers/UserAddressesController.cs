using eNatureBeauty.Model.Requests;
using eNatureBeauty.Model.Requests.UserAddresses;
using eNatureBeauty.WebAPI.Services;

namespace eNatureBeauty.WebAPI.Controllers
{
    public class UserAddressesController : BaseCRUDController<Model.UserAddresses, UserAddressesSearchRequest, UserAddressesUpsertRequest, UserAddressesUpsertRequest>
    {
        public UserAddressesController(ICRUDService<Model.UserAddresses, UserAddressesSearchRequest, UserAddressesUpsertRequest, UserAddressesUpsertRequest> service) : base(service)
        {

        }
    }
}
