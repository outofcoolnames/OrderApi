using OrderApi.Entities;
using System;

namespace OrderApi.DAL
{
    public interface IOrderApiDAL
    {
        /// <summary>
        /// Get the order by the orderId
        /// </summary>
        /// <param name="client">the client</param>
        /// <param name="orderId">the order id</param>
        /// <returns>An OrderEntity instance</returns>
        OrderEntity Get(string client, Guid orderId);
        /// <summary>
        /// Insert an order entity into the database
        /// </summary>
        /// <param name="createOrderEntity">The CreateOrderEntity instance insert</param>
        /// <returns>A CreateOrderEntity</returns>
        IOrderEntity Insert(IOrderEntity createOrderEntity);
    }
}