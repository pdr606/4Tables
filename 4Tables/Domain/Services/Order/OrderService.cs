using _4Tables.Application.Controllers.Order.Adapter;
using _4Tables.Application.Controllers.Order.Dto;
using _4Tables.Domain.Base.Common;
using _4Tables.Domain.Entities.ClienteOder;
using _4Tables.Domain.Entities.Ingredient;
using _4Tables.Domain.Entities.Order;
using _4Tables.Domain.Repositories.Ingredient;
using _4Tables.Domain.Repositories.Order;
using _4Tables.Domain.Services.ClientOrder;

namespace _4Tables.Domain.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IClienteOrderService _clienteOrderService;

        public OrderService(IOrderRepository orderRepository, IClienteOrderService clienteOrderService)
        {
            _orderRepository = orderRepository;
            _clienteOrderService = clienteOrderService;
        }


        public async Task<(OrderEntity order, ClienteOrderEntity clientOrder)> Add(ClientOrderDto dto)
        {

            var clientOrder = await _clienteOrderService.Add(dto);

            if(clientOrder.OrderId == 0)
            {
                var order = new OrderEntity(clientOrder.TableId);

                order.BindingClienteOrder(clientOrder);
                order.CalculatePartialTotal();

                await _orderRepository.Add(order);
                return (order, clientOrder);
            }

            var updatedOrder = await IncrementClientOrder(clientOrder);
            return (updatedOrder, clientOrder);

        }

        public async void Delete(long id)
        {
            var success = await _orderRepository.Delete(id);
        }

        public async Task<List<OrderListResponseDto>> FindAllActives()
        {
            var ordesActives = await _orderRepository.FindAllActives();

            return OrderAdapter.toDtoList(ordesActives);
        }

        private async Task<OrderEntity> IncrementClientOrder(ClienteOrderEntity clienteOrderEntity)
        {
            var order = await _orderRepository.GetById(clienteOrderEntity.OrderId);

            order.BindingClienteOrder(clienteOrderEntity);
            order.CalculatePartialTotal();

            await _orderRepository.Update(order);

            return order;
        }
    }
}
