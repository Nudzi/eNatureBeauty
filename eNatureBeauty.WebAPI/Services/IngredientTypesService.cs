using AutoMapper;
using eNatureBeauty.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace eNatureBeauty.WebAPI.Services
{
    public class IngredientTypesService : IIngredientTypesService
    {
        private readonly natureBeautyContext _context;
        private readonly IMapper _mapper;
        public IngredientTypesService(natureBeautyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.IngredientTypes> Get()
        {
            var list = _context.IngredientTypes.ToList();
            return _mapper.Map<List<Model.IngredientTypes>>(list);
        }

        public Model.IngredientTypes GetById(int id)
        {
            var entity = _context.IngredientTypes.Find(id);

            return _mapper.Map<Model.IngredientTypes>(entity);
        }
    }
}
