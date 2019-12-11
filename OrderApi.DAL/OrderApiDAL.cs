using Microsoft.Extensions.Options;
using OrderApi.Entities;
using OrderApi.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApi.DAL
{
    public class OrderApiDAL : IOrderApiDAL
    {
        private readonly IOptions<ApiAppSettings> config;
        
        /// <summary>
        /// Get the order by the orderId
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public OrderEntity Get(string client, Guid orderId)
        {
            return GetOrders(client)[0];    
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
                ValidateOrder(existingOrders);
            }


            createOrderEntity.OrderId = Guid.NewGuid();
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
                    OrderId = Guid.NewGuid(),
                    Quantity = 100,
                    UnitPrice = 10
                }
            };
        }
        /// <summary>
        /// Validate whether or not the total of existing orders breaches the ClientOutstandingOrderLimit config entry
        /// Validate that no more than ten of any Product is already on order
        /// </summary>
        /// <param name="existingOrders">The list of existing orders</param>
        private void ValidateOrder(List<OrderEntity> existingOrders)
        {
            decimal clientOutstandingOrderLimit = 100;//config.Value.ClientOutstandingOrderLimit;
            decimal existingOrderTotal = 0;            
            int existingOrderTotalQuantity = 0;

            foreach (var order in existingOrders)
            {
                if (order.Quantity > 0)
                {
                    if (order.UnitPrice > 0)
                    {
                        existingOrderTotal += order.Quantity * order.UnitPrice;
                    }
                }
                if(order.Quantity > 0)
                {
                    existingOrderTotalQuantity += order.Quantity;
                }

                if (existingOrderTotal > clientOutstandingOrderLimit)
                {
                    string error = string.Format("The client has outstanding orders with a total value in excess of {0} Euro", 100);
                    throw new ApplicationException(error);
                }

                if(existingOrderTotalQuantity > 100)
                {
                    string error = string.Format("The more than {0} of a Product is already on order", 100);
                    throw new ApplicationException(error);
                }
            }
        }
    }
}
