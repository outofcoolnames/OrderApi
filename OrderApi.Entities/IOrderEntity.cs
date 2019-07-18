using System;

namespace OrderApi.Entities
{
    /// <summary>
    /// Interface describing the entity to create an Order
    /// </summary>
    public interface IOrderEntity
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
        DeliveryAddressEntity DeliveryAddress { get; set; }
        /// <summary>
        /// The internal identifier for the supplied product
        /// </summary>
        Guid? ProductIdInternal { get; set; }
        /// <summary>
        /// The client creating the order
        /// </summary>
        string Client { get; set; }
    }
}