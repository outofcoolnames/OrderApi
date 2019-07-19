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
using OrderApi.Utils;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IOrderEntityFactory _orderEntityFactory;
        private ICreateOrderFactory _createOrderFactory;
        private IOrderApiDAL _dal;
        private IRequestUtils _requestUtils;
        public ProductController(IOrderEntityFactory orderEntityFactory, ICreateOrderFactory createOrderFactory, IOrderApiDAL dal, IRequestUtils requestUtils)
        {
            _orderEntityFactory = orderEntityFactory;            
            _createOrderFactory = createOrderFactory;
            _dal = dal;
            _requestUtils = requestUtils;
        }        

        // GET api/Product/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(Guid orderId)
        {
            var client = _requestUtils.GetClient(Request);
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
            var client = _requestUtils.GetClient(Request);
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
    }
}
