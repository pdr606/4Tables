using _4Tables.Application.Controllers.Order.Dto;
using _4Tables.Domain.Entities.ClienteOder;
using _4Tables.Domain.Repositories.ClientOrder;
using _4Tables.Domain.Services.Product;
using _4Tables.Domain.Services.User;

namespace _4Tables.Domain.Services.ClientOrder
{
    public class ClienteOrderService : IClienteOrderService
    {

        private readonly IClienteOrderRepository _clienteOrderRepository;
        private readonly IProductService _productService;

        public ClienteOrderService(IClienteOrderRepository clienteOrderRepository,
                                   IProductService productService
            )
        {
            _clienteOrderRepository = clienteOrderRepository;
            _productService = productService;
        }

        public async Task<ClienteOrderEntity> Add(ClientOrderDto dto)
        {
            var clientOrder = new ClienteOrderEntity(dto.observation ?? "")
                                                    .WITHORDERID(dto.OrderId ?? null)
                                                    .WITHSTATUS(Base.Enum.StatusEnum.WAITING);

            var products = await _productService.FindAllByListId(dto.productsId);

            clientOrder.BindingProducts(products);

            return clientOrder;

        }
    }
}
