using System.Collections.Generic;
using eNatureBeauty.Model.Requests;

namespace eNatureBeauty.WebAPI.Services
{
    public interface IUsersService
    {
        List<Model.Users> Get(UsersSearchRequest request);
        Model.Users GetById(int id);
        Model.Users Insert(UsersInsertRequest request);
        Model.Users Update(int id, UsersInsertRequest request);
        Model.Users Authentication(string username, string pass);
    }
}
