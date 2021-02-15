using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoragesController : ControllerBase
    {
        private readonly IStoragesService _service;
        public StoragesController(IStoragesService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Model.Storages> Get([FromQuery] StoragesSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpGet("{id}")]
        public Model.Storages GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public void Insert(StoragesUpsertRequest request)
        {
            _service.Insert(request);
        }
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] StoragesUpsertRequest request)
        {
            _service.Update(id, request);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
