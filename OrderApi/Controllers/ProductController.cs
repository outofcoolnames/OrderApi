using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using OrderApi.DAL;
using OrderApi.ModelFactory;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IOrderEntityFactory _orderEntityFactory;
        private IOrderApiDAL _dal;
        public ProductController(IOrderEntityFactory orderEntityFactory, IOrderApiDAL dal)
        {
            _orderEntityFactory = orderEntityFactory;
            _dal = dal;
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
        public IActionResult Post([FromBody] CreateOrder dto)
        {
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]).Parameter;
            string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader));            
            var client = decodedToken.Substring(0, decodedToken.IndexOf(":"));
             var order = _orderEntityFactory.GetOrderEntity(dto, client);
            try
            {
                _dal.Insert(order); //dal may throw exceptions...
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }       
    }
}
