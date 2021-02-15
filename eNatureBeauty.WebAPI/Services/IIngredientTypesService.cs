using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Services
{
    public interface IIngredientTypesService
    {
        List<Model.IngredientTypes> Get();
        
        Model.IngredientTypes GetById(int id);
    }
}
