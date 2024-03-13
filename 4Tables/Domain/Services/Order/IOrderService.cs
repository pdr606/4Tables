using _4Tables.Domain.Base.Services;
using _4Tables.Domain.Entities.Order;

namespace _4Tables.Domain.Services.Order
{
    public interface IOrderService : IDomainService<OrderEntity>
    {
        void Delete(long id);
    }
}
