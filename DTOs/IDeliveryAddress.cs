namespace DTOs
{
    /// <summary>
    /// Interface describing the DeliveryAddress
    /// </summary>
    public interface IDeliveryAddress
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
    }
}