using System.Collections.Generic;
using eNatureBeauty.Model.Requests;

namespace eNatureBeauty.WebAPI.Services
{
    public interface IWishlistsService
    {
        List<Model.Wishlists> Get(WishlistsSearchRequest request);
        Model.Wishlists GetById(int id);
        void Insert(WishlistsUpsertRequest request);
        void Update(int id, WishlistsUpsertRequest request);
        void Delete(int id);
    }
}
