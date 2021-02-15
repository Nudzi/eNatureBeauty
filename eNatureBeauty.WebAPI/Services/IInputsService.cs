using System.Collections.Generic;
using eNatureBeauty.Model.Requests.Inputs;

namespace eNatureBeauty.WebAPI.Services
{
    public interface IInputsService
    {
        List<Model.Inputs> Get(InputsSearchRequest request);
        Model.Inputs GetById(int id);
        void Insert(InputsUpsertRequest request);
        void Update(int id, InputsUpsertRequest request);
    }
}
