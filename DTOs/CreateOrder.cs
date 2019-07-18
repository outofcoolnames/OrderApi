using System;

namespace DTOs
{
    /// <summary>
    /// Class describing the data transfer object to create an Order
    /// </summary>
    public class CreateOrder : ICreateOrder
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
        public DeliveryAddress DeliveryAddress { get; set; }
    }
}
