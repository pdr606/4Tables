using _4Tables.Application.Controllers.Order.Dto;
using _4Tables.Application.Controllers.Product.Adapter;
using _4Tables.Domain.Entities.ClienteOder;
using _4Tables.Domain.Entities.Order;

namespace _4Tables.Application.Controllers.Order.Adapter
{
    public partial class OrderAdapter
    {

        internal static ClientOrderResponseDto toDto(OrderEntity order, ClienteOrderEntity clienteOrder)
        {
            return new ClientOrderResponseDto(clienteOrder.Id,
                                              clienteOrder.Observation,
                                              ProductAdapter.ToDtoList(clienteOrder.Products),
                                              clienteOrder.TableId,
                                              order.Id,
                                              clienteOrder.Status
                                              );
        }

        internal static List<OrderListResponseDto> toDtoList(List<OrderEntity> order)
        {
           List<OrderListResponseDto> responseList = new List<OrderListResponseDto>();

            foreach (OrderEntity orderEntity in order)
            {
                responseList.Add(new OrderListResponseDto(orderEntity.Id,
                                                          orderEntity.TableId,
                                                          orderEntity.Total.ToString(),
                                                          orderEntity.Created_At.AddHours(-3).ToString("HH:mm:ss")

                    ));
            }

            return responseList;
        }
    }
}
