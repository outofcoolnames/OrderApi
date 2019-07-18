using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Utils;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IHttpUtils _httpUtils;
        public ProductController(IHttpUtils httpUtils)
        {
            _httpUtils = httpUtils;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        /// <summary>
        /// Receive a CreateOrder
        /// </summary>
        /// <param name="dto">A CreateOrder instance</param>
        [HttpPost]
        public void Post([FromBody] CreateOrder dto)
        {
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var client = _httpUtils.GetUserNameAndPassword(authHeader.Parameter).Key;

        }       
    }
}
