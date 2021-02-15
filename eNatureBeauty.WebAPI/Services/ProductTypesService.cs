using AutoMapper;
using eNatureBeauty.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace eNatureBeauty.WebAPI.Services
{
    public class ProductTypesService : IProductTypesService
    {
        private readonly natureBeautyContext _context;
        private readonly IMapper _mapper;
        public ProductTypesService(natureBeautyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.ProductTypes> Get()
        {
            var list = _context.ProductTypes.ToList();
            return _mapper.Map<List<Model.ProductTypes>>(list);
        }

        public Model.ProductTypes GetById(int id)
        {
            var entity = _context.ProductTypes.Find(id);

            return _mapper.Map<Model.ProductTypes>(entity);
        }
    }
}
