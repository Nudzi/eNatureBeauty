using eNatureBeauty.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommenderController : ControllerBase
    {
        private readonly IRecommender _service;

        public RecommenderController(IRecommender service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAlikeProducts/{productId}")]
        public List<Model.Products> GetAlikeProducts(int productId)
        {
            return _service.GetAlikeProducts(productId);
        }
    }
}
