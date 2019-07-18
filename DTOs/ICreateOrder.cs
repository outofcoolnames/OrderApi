using System;

namespace DTOs
{
    /// <summary>
    /// Interface describing the data transfer object to create an Order
    /// </summary>
    public interface ICreateOrder
    {
        /// <summary>
        /// The ProductId
        /// </summary>
        Guid ProductId { get; set; }
        /// <summary>
        /// The Quantity
        /// </summary>
        int Quantity { get; set; }
        /// <summary>
        /// The UnitPrice
        /// </summary>
        decimal UnitPrice { get; set; }
        /// <summary>
        /// The DeliveryAddress
        /// </summary>
        DeliveryAddress DeliveryAddress { get; set; }
    }
}