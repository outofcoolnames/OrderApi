using OrderApi.Entities;
using System.Threading.Tasks;

namespace OrderApi.DAL
{
    public interface IOrderApiDAL
    {
        IOrderEntity Insert(IOrderEntity createOrderEntity);
    }
}