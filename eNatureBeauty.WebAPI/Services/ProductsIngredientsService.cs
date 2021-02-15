using AutoMapper;
using eNatureBeauty.Model;
using eNatureBeauty.Model.Requests.ProductsIngredients;
using eNatureBeauty.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace eNatureBeauty.WebAPI.Services
{
    public class ProductsIngredientsService : BaseCRUDService<Model.ProductsIngredients, ProductsIngredientsSearchRequest, ProductsIngredientsUpsertRequest, ProductsIngredientsUpsertRequest, ProductIngredients>
    {
        public ProductsIngredientsService(natureBeautyContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IList<Model.ProductsIngredients> Get(ProductsIngredientsSearchRequest request)
        {
            var query = _context.Set<ProductIngredients>().AsQueryable();
            if (request?.ProductID.HasValue == true)
            {
                query = query.Where(x => x.ProductId == request.ProductID);
            }
            var list = query.ToList();

            return _mapper.Map<List<Model.ProductsIngredients>>(list);
        }
    }
}
