using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistsController : ControllerBase
    {
        private readonly IWishlistsService _service;
        public WishlistsController(IWishlistsService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Model.Wishlists> Get([FromQuery] WishlistsSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpGet("{id}")]
        public Model.Wishlists GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public void Insert(WishlistsUpsertRequest request)
        {
            _service.Insert(request);
        }
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] WishlistsUpsertRequest request)
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
