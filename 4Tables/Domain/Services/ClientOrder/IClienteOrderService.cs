using _4Tables.Application.Controllers.Order.Dto;
using _4Tables.Domain.Base.Services;
using _4Tables.Domain.Entities.ClienteOder;
using System.Threading.Tasks;

namespace _4Tables.Domain.Services.ClientOrder
{
    public interface IClienteOrderService : IDomainService<ClienteOrderEntity>
    {

        Task<ClienteOrderEntity> Add(ClientOrderDto dto);
    }
}
