
using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsIngredientTypesController : ControllerBase
    {
        private readonly IIngredientsIngredientTypesService _service;
        public IngredientsIngredientTypesController(IIngredientsIngredientTypesService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Model.IngredientsIngredientTypes> Get([FromQuery] IngredientsSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpGet("{id}")]
        public Model.IngredientsIngredientTypes GetById(int id)
        {
            return _service.GetById(id);
        }

        //[HttpPost]
        //public void Insert(IngredientsIngredientTypesUpsertRequest request)
        //{
        //    _service.Insert(request);
        //}
        //[HttpPut("{id}")]
        //public void Update(int id, [FromBody] IngredientsIngredientTypesUpsertRequest request)
        //{
        //    _service.Update(id, request);
        //}
    }
}
