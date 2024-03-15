using _4Tables.Application.Controllers.Order.Adapter;
using _4Tables.Application.Controllers.Order.Dto;
using _4Tables.Domain.Base.Common;
using _4Tables.Domain.Entities.ClienteOder;
using _4Tables.Domain.Entities.Order;
using _4Tables.Domain.Services.ClientOrder;
using _4Tables.Domain.Services.Order;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace _4Tables.Application.Controllers.Order
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController
    {

        private readonly IOrderService _orderService;
        private readonly IClienteOrderService _clienteOrderService;

        public OrderController(IOrderService orderService, IClienteOrderService clienteOrderService)
        {
            _orderService = orderService;
            _clienteOrderService = clienteOrderService;
        }

        [HttpPost]
        public async Task<ClientOrderResponseDto> Add([FromBody] ClientOrderDto dto)
        {
            (OrderEntity order, ClienteOrderEntity clientOrder) = await _orderService.Add(dto);

            return OrderAdapter.toDto(order, clientOrder);

        }

        [HttpGet]
        public async Task<List<OrderListResponseDto>> FindAllActives()
        {
           return await _orderService.FindAllActives();
        }
    }
}
