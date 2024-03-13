using _4Tables.Domain.Base.Services;
using _4Tables.Domain.Entities.ClienteOder;

namespace _4Tables.Domain.Services.ClientOrder
{
    public interface IClienteOrderService : IDomainService<ClienteOrderEntity>
    {

        Task Add(ClienteOrderEntity entity);
    }
}
