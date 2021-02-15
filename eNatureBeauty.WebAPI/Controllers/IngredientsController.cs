using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientsService _service;
        public IngredientsController(IIngredientsService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Model.Ingredients> Get([FromQuery] IngredientsSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpGet("{id}")]
        public Model.Ingredients GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public void Insert(IngredientsUpsertRequest request)
        {
            _service.Insert(request);
        }
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] IngredientsUpsertRequest request)
        {
            _service.Update(id, request);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
