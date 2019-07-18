using AutoMapper;
using DTOs;
using OrderApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApi.ModelFactory
{
    /// <summary>
    /// Class containing methods returning instances
    /// </summary>
    public class OrderEntityFactory : IOrderEntityFactory
    {
        private IMapper _mapper { get; set; }
        public OrderEntityFactory()
        {
            if (_mapper == null)
            {
                _mapper = InitializeAutoMapper();
            }
        }
        /// <summary>
        /// Return an OrderEntity instance
        /// </summary>
        /// <param name="dto">The source CreateOrder DTO</param>
        /// <param name="client">The client</param>
        /// <returns>An OrderEntity instance</returns>
        public OrderEntity GetOrderEntity(CreateOrder dto, string client)
        {
            var orderEntity = _mapper.Map<OrderEntity>(dto);
            orderEntity.Client = client;
            return orderEntity;
        }
        /// <summary>
        /// Initialize the AutoMapper used by the class
        /// </summary>
        /// <returns>IMapper instance</returns>
        private IMapper InitializeAutoMapper()
        {
            var mc = new MapperConfiguration(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.AllowNullDestinationValues = true;
                cfg.AllowNullCollections = true;

                cfg.AddProfile<AutoMapperProfile>();
            });

            var mapper = mc.CreateMapper();
            return mapper;
        }
    }
}
