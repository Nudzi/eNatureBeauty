using AutoMapper;
using eNatureBeauty.Model.Requests.InputProducts;
using eNatureBeauty.Model.Requests.Inputs;
using eNatureBeauty.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace eNatureBeauty.WebAPI.Services
{
    public class InputProductsService : BaseCRUDService<Model.InputProducts, InputProductsSearchRequest, InputProductsUpsertRequest, InputProductsUpsertRequest, InputProducts>
    {
        public InputProductsService(natureBeautyContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IList<Model.InputProducts> Get(InputProductsSearchRequest request = null)
        {
            var query = _context.Set<InputProducts>().AsQueryable();
            if (request?.ProductId.HasValue == true)
            {
                query = query.Where(x => x.ProductId == request.ProductId);
            }
            if (request?.InputId.HasValue == true)
            {
                query = query.Where(x => x.InputId == request.InputId);
            }
            var list = query.ToList();

            return _mapper.Map<List<Model.InputProducts>>(list);
        }
    }
}

