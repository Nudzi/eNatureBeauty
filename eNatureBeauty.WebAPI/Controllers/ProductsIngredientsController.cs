using eNatureBeauty.Model.Requests.ProductsIngredients;
using eNatureBeauty.WebAPI.Services;

namespace eNatureBeauty.WebAPI.Controllers
{
    public class ProductsIngredientsController : BaseCRUDController<Model.ProductsIngredients, ProductsIngredientsSearchRequest, ProductsIngredientsUpsertRequest, ProductsIngredientsUpsertRequest>
    {
        public ProductsIngredientsController(ICRUDService<Model.ProductsIngredients, ProductsIngredientsSearchRequest, ProductsIngredientsUpsertRequest, ProductsIngredientsUpsertRequest> service) : base(service)
        {

        }
    }
}

