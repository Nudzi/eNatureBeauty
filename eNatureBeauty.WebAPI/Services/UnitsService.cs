using AutoMapper;
using eNatureBeauty.Model.Requests.Units;
using eNatureBeauty.WebAPI.Database;

namespace eNatureBeauty.WebAPI.Services
{
    public class UnitsService : BaseService<Model.Units, UnitsSearchRequest, Units>
    {
        public UnitsService(natureBeautyContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
