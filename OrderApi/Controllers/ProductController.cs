using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {   
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
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]).Parameter;
            string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader));            
            var client = decodedToken.Substring(0, decodedToken.IndexOf(":"));
            //todo: construct entity and store order

        }       
    }
}
