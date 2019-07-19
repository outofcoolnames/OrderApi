using DTOs;
using OrderApi.Entities;

namespace OrderApi.ModelFactory
{
    public interface ICreateOrderFactory
    {
        CreateOrder GetCreateOrder(OrderEntity entity);
    }
}