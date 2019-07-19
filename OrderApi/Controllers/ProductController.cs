using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Microsoft.AspNetCore.Http;
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
        private ICreateOrderFactory _createOrderFactory;
        private IOrderApiDAL _dal;
        public ProductController(IOrderEntityFactory orderEntityFactory, ICreateOrderFactory createOrderFactory, IOrderApiDAL dal)
        {
            _orderEntityFactory = orderEntityFactory;            
            _createOrderFactory = createOrderFactory;
            _dal = dal;
        }        

        // GET api/Product/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(Guid orderId)
        {
            var client = GetClient(Request);
            var dalResponse = _dal.Get(client,orderId);
            if(dalResponse != null)
            {
                var dto = _createOrderFactory.GetCreateOrder(dalResponse);
                return Ok(dto);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/Product
        /// <summary>
        /// Receive a CreateOrder
        /// </summary>
        /// <param name="dto">A CreateOrder instance</param>
        [HttpPost]
        public IActionResult Post([FromBody] CreateOrder dto)
        {
            var client = GetClient(Request);
             var order = _orderEntityFactory.GetOrderEntity(dto, client);
            try
            {
                var response = _dal.Insert(order); //dal may throw exceptions...
                return CreatedAtRoute("/api/Product/", response.OrderId);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        /// <summary>
        /// Get the client from the Basic auth supplied
        /// </summary>
        /// <param name="request">The current request</param>
        /// <returns>THe username supplied</returns>
        private string GetClient(HttpRequest request)
        {
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]).Parameter;
            string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader));
            return decodedToken.Substring(0, decodedToken.IndexOf(":"));
        }
    }
}
