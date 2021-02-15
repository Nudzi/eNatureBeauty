using AutoMapper;
using eNatureBeauty.Model.Requests.UserAddresses;
using eNatureBeauty.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace eNatureBeauty.WebAPI.Services
{
    public class UserAddressesService : BaseCRUDService<Model.UserAddresses, UserAddressesSearchRequest, UserAddressesUpsertRequest, UserAddressesUpsertRequest, UserAddresses>
    {
        public UserAddressesService(natureBeautyContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IList<Model.UserAddresses> Get(UserAddressesSearchRequest request)
        {
            var query = _context.Set<UserAddresses>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.Country))
            {
                query = query.Where(x => x.Country.StartsWith(request.Country));
            }
            if (!string.IsNullOrWhiteSpace(request?.AddressName))
            {
                query = query.Where(x => x.AddressName.StartsWith(request.AddressName));
            }
            query = query.OrderBy(x => x.AddressName);
            var list = query.ToList();

            return _mapper.Map<List<Model.UserAddresses>>(list);
        }
    }
}
