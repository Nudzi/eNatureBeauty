using eNatureBeauty.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypesController : ControllerBase
    {
        private readonly IUserTypesService _service;

        public UserTypesController(IUserTypesService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.UserTypes> Get()
        {
            return _service.Get();
        }
        [HttpGet("{id}")]
        public Model.UserTypes GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpGet]
        [Route("isAdmin/{userTypeId}")]
        public Model.UserTypes isAdmin(int userTypeId)
        {
            return _service.isAdmin(userTypeId);
        }

    }
}
