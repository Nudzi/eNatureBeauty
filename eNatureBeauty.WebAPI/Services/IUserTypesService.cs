using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Services
{
    public interface IUserTypesService
    {
        List<Model.UserTypes> Get();
        Model.UserTypes GetById(int id);
        Model.UserTypes isAdmin(int UlogaId);
    }
}
