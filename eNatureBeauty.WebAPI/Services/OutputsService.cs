using AutoMapper;
using eNatureBeauty.Model.Requests.Outputs;
using eNatureBeauty.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace eNatureBeauty.WebAPI.Services
{
    public class OutputsService : BaseCRUDService<Model.Outputs, OutputsSearchRequest, OutputsUpsertRequest, OutputsUpsertRequest, Outputs>
    {
        public OutputsService(natureBeautyContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IList<Model.Outputs> Get(OutputsSearchRequest request = null)
        {
            var query = _context.Set<Outputs>().AsQueryable();
            if (request?.OrderId.HasValue == true)
            {
                query = query.Where(x => x.OrderId == request.OrderId);
            }
            if (!string.IsNullOrWhiteSpace(request?.ReceiveNumber))
            {
                query = query.Where(x => x.ReceiveNumber.StartsWith(request.ReceiveNumber));
            }
            query = query.OrderBy(x => x.ReceiveNumber);
            var list = query.ToList();

            return _mapper.Map<List<Model.Outputs>>(list);
        }
    }
}
