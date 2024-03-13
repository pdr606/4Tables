using _4Tables.Domain.Entities.ClienteOder;
using _4Tables.Domain.Repositories.ClientOrder;

namespace _4Tables.Domain.Services.ClientOrder
{
    public class ClienteOrderService : IClienteOrderService
    {

        private readonly IClienteOrderRepository _clienteOrderRepository;

        public ClienteOrderService(IClienteOrderRepository clienteOrderRepository)
        {
            _clienteOrderRepository = clienteOrderRepository;
        }

        public Task Add(ClienteOrderEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
