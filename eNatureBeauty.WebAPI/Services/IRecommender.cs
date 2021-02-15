using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Services
{
    public interface IRecommender
    {
        List<Model.Products> GetAlikeProducts(int productId);
    }
}
