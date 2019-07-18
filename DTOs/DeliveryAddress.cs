namespace DTOs
{
    /// <summary>
    /// Class describing the DeliveryAddress
    /// </summary>
    public class DeliveryAddress : IDeliveryAddress
    {
        /// <summary>
        /// The Address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// The Address2
        /// </summary>
        public string Address2 { get; set; }
        /// <summary>
        /// The County
        /// </summary>
        public string County { get; set; }
        /// <summary>
        /// The State
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// The PostalCode
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// The Country
        /// </summary>
        public string Country { get; set; }
    }
}
