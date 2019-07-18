using System;

namespace OrderApi.Entities
{
    /// <summary>
    /// Interface describing the DeliveryAddressEntity
    /// </summary>
    public interface IDeliveryAddressEntity
    {
        /// <summary>
        /// The Address
        /// </summary>
        string Address { get; set; }
        /// <summary>
        /// The Address2
        /// </summary>
        string Address2 { get; set; }
        /// <summary>
        /// The County
        /// </summary>
        string County { get; set; }
        /// <summary>
        /// The State
        /// </summary>
        string State { get; set; }
        /// <summary>
        /// The PostalCode
        /// </summary>
        string PostalCode { get; set; }
        /// <summary>
        /// The Country
        /// </summary>
        string Country { get; set; }
        /// <summary>
        /// The internal identifier for the supplied DeliveryAddressEntity
        /// </summary>
        Guid? DeliveryAddressIdInternal { get; set; }
    }
}