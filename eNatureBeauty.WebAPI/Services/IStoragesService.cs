using eNatureBeauty.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNatureBeauty.WebAPI.Services
{
    public interface IStoragesService
    {
        List<Model.Storages> Get(StoragesSearchRequest request);

        Model.Storages GetById(int id);
        void Insert(StoragesUpsertRequest request);
        void Update(int id, StoragesUpsertRequest request);
        void Delete(int id);
    }
}
