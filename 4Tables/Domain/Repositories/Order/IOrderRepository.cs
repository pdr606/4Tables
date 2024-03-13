using _4Tables.Domain.Base.Repositories;
using _4Tables.Domain.Entities.Order;

namespace _4Tables.Domain.Repositories.Order
{
    public interface IOrderRepository : IDomainRepository<OrderEntity>
    {
        Task<bool> Delete(long id);
    }
}
