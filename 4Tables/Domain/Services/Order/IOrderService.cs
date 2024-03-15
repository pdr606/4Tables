using _4Tables.Application.Controllers.Order.Dto;
using _4Tables.Domain.Base.Services;
using _4Tables.Domain.Entities.ClienteOder;
using _4Tables.Domain.Entities.Order;

namespace _4Tables.Domain.Services.Order
{
    public interface IOrderService : IDomainService<OrderEntity>
    {
        void Delete(long id);
        public Task<List<OrderListResponseDto>> FindAllActives();
        public Task<(OrderEntity order, ClienteOrderEntity clientOrder)> Add(ClientOrderDto dto);
    }
}
