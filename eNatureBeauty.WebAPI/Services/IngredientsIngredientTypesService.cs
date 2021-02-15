using AutoMapper;
using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace eNatureBeauty.WebAPI.Services
{
    public class IngredientsIngredientTypesService : IIngredientsIngredientTypesService
    {
        private readonly natureBeautyContext _context;
        private readonly IMapper _mapper;
        public IngredientsIngredientTypesService(natureBeautyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.IngredientsIngredientTypes> Get(IngredientsSearchRequest request)
        {
            var query = _context.Set<IngredientsIngredientTypes>().AsQueryable();
            if (request?.IngredientTypeID.HasValue == true)
            {
                query = query.Where(x => x.IngredientTypeId == request.IngredientTypeID);
            }
            if (request?.IngredientID.HasValue == true)
            {
                query = query.Where(x => x.IngredientId == request.IngredientID);
            }
            var list = query.ToList();

            return _mapper.Map<List<Model.IngredientsIngredientTypes>>(list);
        }

        public Model.IngredientsIngredientTypes GetById(int id)
        {
            var entity = _context.IngredientsIngredientTypes.Find(id);

            return _mapper.Map<Model.IngredientsIngredientTypes>(entity);
        }
    }
}
