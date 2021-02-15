using System.Collections.Generic;
using eNatureBeauty.Model.Requests;

namespace eNatureBeauty.WebAPI.Services
{
    public interface IIngredientsIngredientTypesService
    {
        List<Model.IngredientsIngredientTypes> Get(IngredientsSearchRequest request);
        
        Model.IngredientsIngredientTypes GetById(int id);
    }
}
