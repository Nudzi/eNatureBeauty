using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Reviews = eNatureBeauty.Model.Reviews.Reviews;

namespace eNatureBeauty.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsService _service;
        public ReviewsController(IReviewsService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Reviews> Get([FromQuery] ReviewsSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpGet("{id}")]
        public Reviews GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public void Insert(ReviewsUpsertRequest request)
        {
            _service.Insert(request);
        }
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] ReviewsUpsertRequest request)
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