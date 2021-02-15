using AutoMapper;
using eNatureBeauty.Model.Requests.Inputs;
using eNatureBeauty.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace eNatureBeauty.WebAPI.Services
{
    public class InputsService : BaseCRUDService<Model.Inputs, InputsSearchRequest, InputsUpsertRequest, InputsUpsertRequest, Inputs>
    {
        public InputsService(natureBeautyContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IList<Model.Inputs> Get(InputsSearchRequest request)
        {
            var query = _context.Set<Inputs>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.InvoiceNumber))
            {
                query = query.Where(x => x.InvoiceNumber.StartsWith(request.InvoiceNumber));
            }
            query = query.OrderBy(x => x.InvoiceNumber);
            var list = query.ToList();

            return _mapper.Map<List<Model.Inputs>>(list);
        }
    }
}
