using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Services
{
    public interface IProductTypesService
    {
        List<Model.ProductTypes> Get();
        
        Model.ProductTypes GetById(int id);
    }
}
