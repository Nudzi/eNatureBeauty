using AutoMapper;
using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace eNatureBeauty.WebAPI.Services
{
    public class IngredientsService : IIngredientsService
    {
        private readonly natureBeautyContext _context;
        private readonly IMapper _mapper;
        public IngredientsService(natureBeautyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            var entity = _context.Ingredients.Find(id);
            _context.Ingredients.Remove(entity);
            _context.SaveChanges();
        }

        public List<Model.Ingredients> Get(IngredientsSearchRequest request)
        {
            var query = _context.Set<Ingredients>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.StartsWith(request.Name));
            }
            query = query.OrderBy(x => x.Name);
            var list = query.ToList();

            return _mapper.Map<List<Model.Ingredients>>(list);
        }

        public Model.Ingredients GetById(int id)
        {
            var entity = _context.Ingredients.Find(id);

            return _mapper.Map<Model.Ingredients>(entity);
        }
        public void Insert(IngredientsUpsertRequest request)
        {
            Database.Ingredients entity = _mapper.Map<Database.Ingredients>(request);
            _context.Ingredients.Add(entity);
            _context.SaveChanges();

            foreach (var type in request.IngredientsTypes)
            {
                _context.IngredientsIngredientTypes.Add(new Database.IngredientsIngredientTypes()
                {
                    IngredientTypeId = type,
                    IngredientId = entity.Id,
                    Description = ""
                });
            }

            _context.SaveChanges();
        }
        public void Update(int id, IngredientsUpsertRequest request)
        {
            var entity = _context.Ingredients.Find(id);
            _context.Ingredients.Attach(entity);
            _context.Ingredients.Update(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
        }

    }
}
