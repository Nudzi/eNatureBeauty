﻿using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _service;
        public UsersController(IUsersService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Model.Users> Get([FromQuery] UsersSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpGet("{id}")]
        public Model.Users GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public Model.Users Insert(UsersInsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut("{id}")]
        public void Update(int id, [FromBody]UsersInsertRequest request)
        {
             _service.Update(id, request);
        }
        [HttpGet]
        [Route("Authentication/{username},{password}")]
        public Model.Users Authentication(string username, string password)
        {
            return _service.Authentication(username, password);
        }
    }
}
