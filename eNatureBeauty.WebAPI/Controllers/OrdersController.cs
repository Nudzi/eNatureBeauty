using eNatureBeauty.Model.Requests;
using eNatureBeauty.Model.Requests.Orders;
using eNatureBeauty.WebAPI.Services;

namespace eNatureBeauty.WebAPI.Controllers
{
    public class OrdersController : BaseCRUDController<Model.Orders, OrdersSearchRequest, OrdersUpsertRequest, OrdersUpsertRequest>
    {
        public OrdersController(ICRUDService<Model.Orders, OrdersSearchRequest, OrdersUpsertRequest, OrdersUpsertRequest> service) : base(service)
        {

        }
    }
}