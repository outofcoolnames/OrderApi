using AutoMapper;
using DTOs;
using OrderApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApi.ModelFactory
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateOrder, OrderEntity>();
            CreateMap<DeliveryAddress, DeliveryAddressEntity>();
        }
    }
}
