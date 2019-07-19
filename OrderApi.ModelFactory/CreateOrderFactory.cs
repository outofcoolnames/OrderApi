using AutoMapper;
using DTOs;
using OrderApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApi.ModelFactory
{
    public class CreateOrderFactory : ICreateOrderFactory
    {
        private IMapper _mapper { get; set; }
        public CreateOrderFactory()
        {
            if (_mapper == null)
            {
                _mapper = InitializeAutoMapper();
            }
        }
        /// <summary>
        /// Get a CreateOrder instance from a OrderEntity instance
        /// </summary>
        /// <param name="entity">A OrderEntity instance</param>
        /// <returns>A CreateOrder instance </returns>
        public CreateOrder GetCreateOrder(OrderEntity entity)
        {
            return _mapper.Map<CreateOrder>(entity);
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
