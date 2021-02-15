using AutoMapper;
using eNatureBeauty.Model.Requests.Orders;
using eNatureBeauty.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace eNatureBeauty.WebAPI.Services
{
    public class OrdersService : BaseCRUDService<Model.Orders, OrdersSearchRequest, OrdersUpsertRequest, OrdersUpsertRequest, Orders>
    {
        public OrdersService(natureBeautyContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IList<Model.Orders> Get(OrdersSearchRequest request)
        {
            var query = _context.Set<Orders>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.OrderNumber))
            {
                query = query.Where(x => x.OrderNumber.StartsWith(request.OrderNumber));
            }
            if (request?.UserId.HasValue == true)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }
            query = query.OrderBy(x => x.OrderNumber);
            var list = query.ToList();

            return _mapper.Map<List<Model.Orders>>(list);
        }
    }
}
