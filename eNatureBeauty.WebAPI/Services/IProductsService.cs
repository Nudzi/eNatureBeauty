using System.Collections.Generic;
using eNatureBeauty.Model.Requests;

namespace eNatureBeauty.WebAPI.Services
{
    public interface IProductsService
    {
        List<Model.Products> Get(ProductsSearchRequest request);
        Model.Products GetById(int id);
        void Insert(ProductsUpsertRequest request);
        Model.Products Update(int id, ProductsUpsertRequest request);
    }
}
