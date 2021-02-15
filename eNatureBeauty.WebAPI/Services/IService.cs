using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Services
{
    public interface IService<T, TSearch>
    {
        IList<T> Get(TSearch search = default(TSearch));
        T GetById(int id);
    }
}
