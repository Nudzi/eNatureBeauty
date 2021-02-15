using AutoMapper;
using eNatureBeauty.Model.Requests.OutputProducts;
using eNatureBeauty.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace eNatureBeauty.WebAPI.Services
{
    public class OutputProductsService : BaseCRUDService<Model.OutputProducts, OutputProductsSearchRequest, OutputProductsUpsertRequest, OutputProductsUpsertRequest, OutputProducts>
    {
        public OutputProductsService(natureBeautyContext context, IMapper mapper) : base(context, mapper)
        {
        }
    public override IList<Model.OutputProducts> Get(OutputProductsSearchRequest request = null)
        {
            var query = _context.Set<OutputProducts>().AsQueryable();
            if (request?.OutputId.HasValue == true)
            {
                query = query.Where(x => x.OutputId == request.OutputId);
            }
            if (request?.ProductId.HasValue == true)
            {
                query = query.Where(x => x.ProductId == request.ProductId);
            }
            var list = query.ToList();

            return _mapper.Map<List<Model.OutputProducts>>(list);
        }
    }
}
