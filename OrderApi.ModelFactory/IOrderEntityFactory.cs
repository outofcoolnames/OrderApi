using DTOs;
using OrderApi.Entities;

namespace OrderApi.ModelFactory
{
    /// <summary>
    /// Class containing methods returning instances
    /// </summary>
    public interface IOrderEntityFactory
    {
        /// <summary>
        /// Return an OrderEntity instance
        /// </summary>
        /// <param name="dto">The source CreateOrder DTO</param>
        /// <param name="client">The client</param>
        /// <returns>An OrderEntity instance</returns>
        OrderEntity GetOrderEntity(CreateOrder dto, string client);
    }
}