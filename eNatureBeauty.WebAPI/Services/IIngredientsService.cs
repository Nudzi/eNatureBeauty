using System.Collections.Generic;
using eNatureBeauty.Model.Requests;

namespace eNatureBeauty.WebAPI.Services
{
    public interface IIngredientsService
    {
        List<Model.Ingredients> Get(IngredientsSearchRequest request);
        
        Model.Ingredients GetById(int id);
        void Insert(IngredientsUpsertRequest request);
        void Update(int id, IngredientsUpsertRequest request);
        void Delete(int id);
    }
}
