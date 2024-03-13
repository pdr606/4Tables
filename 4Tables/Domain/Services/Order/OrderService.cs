using _4Tables.Domain.Entities.Ingredient;
using _4Tables.Domain.Entities.Order;
using _4Tables.Domain.Repositories.Ingredient;
using _4Tables.Domain.Repositories.Order;

namespace _4Tables.Domain.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Add(OrderEntity entity)
        {
            _orderRepository.Add(entity);

        }

        public async void Delete(long id)
        {
            var success = await _orderRepository.Delete(id);
        }
    }
}
