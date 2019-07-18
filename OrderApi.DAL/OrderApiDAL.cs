using Microsoft.Extensions.Configuration;
using OrderApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApi.DAL
{
    public class OrderApiDAL : IOrderApiDAL
    {
        private readonly IConfiguration _configuration = null;
        public OrderApiDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Insert an order entity into the database
        /// </summary>
        /// <param name="createOrderEntity">The CreateOrderEntity instance insert</param>
        /// <returns>A CreateOrderEntity</returns>
        public IOrderEntity Insert(IOrderEntity createOrderEntity)
        {
            var existingOrders = GetOrders(createOrderEntity.Client);
            if (existingOrders.Count > 0)
            {
                ValidateClientOutstandingOrderLimit(existingOrders);
            }


            createOrderEntity.ProductIdInternal = Guid.NewGuid();
            return createOrderEntity;
        }
        private List<OrderEntity> GetOrders(string client)
        {
            return new List<OrderEntity>()
            {
                new OrderEntity
                {
                    Client = client,
                    DeliveryAddress =new DeliveryAddressEntity
                    {
                        Address = string.Empty,
                        Address2 = string.Empty,
                        Country = string.Empty,
                        County = string.Empty,
                        DeliveryAddressIdInternal = Guid.NewGuid(),
                        PostalCode = string.Empty,
                        State = string.Empty
                    },
                    ProductId = Guid.NewGuid(),
                    ProductIdInternal = Guid.NewGuid(),
                    Quantity = 0,
                    UnitPrice = 1
                }
            };
        }
        /// <summary>
        /// Validate whether or not the total of existing orders breaches the ClientOutstandingOrderLimit config entry
        /// </summary>
        /// <param name="existingOrders">The list of existing orders</param>
        private void ValidateClientOutstandingOrderLimit(List<OrderEntity> existingOrders)
        {
            decimal clientOutstandingOrderLimit = Convert.ToDecimal(_configuration["ClientOutstandingOrderLimit"]);
            decimal existingOrderTotal = 0;
            int existingOrderCountTotal = Convert.ToInt32(_configuration["ClientOrderCountLimit"]);

            foreach (var order in existingOrders)
            {
                if (order.Quantity > 0)
                {
                    if (order.UnitPrice > 0)
                    {
                        existingOrderTotal += order.Quantity * order.UnitPrice;
                    }
                }
                if (existingOrderTotal > clientOutstandingOrderLimit)
                {
                    string error = string.Format("client has outstanding orders with a total value in excess of {0} Euro", _configuration["ClientOutstandingOrderLimit"]);
                    throw new ApplicationException("error");
                }
            }
        }
    }
}
