using System;

namespace OrderApi.Entities
{
    /// <summary>
    /// Class describing the entity to create an Order
    /// </summary>
    public class OrderEntity : IOrderEntity
    {
        /// <summary>
        /// The ProductId
        /// </summary>
        public Guid ProductId { get; set; }
        /// <summary>
        /// The Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// The UnitPrice
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// The DeliveryAddress
        /// </summary>
        public DeliveryAddressEntity DeliveryAddress { get; set; }
        /// <summary>
        /// The identifier for the order
        /// </summary>
        public Guid? OrderId { get; set; }
        /// <summary>
        /// The client creating the order
        /// </summary>
        public string Client { get; set; }
    }
}
