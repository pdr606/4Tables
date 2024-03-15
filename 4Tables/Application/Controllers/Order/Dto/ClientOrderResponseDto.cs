using _4Tables.Application.Controllers.Product.Dto;
using _4Tables.Domain.Base.Enum;

namespace _4Tables.Application.Controllers.Order.Dto
{
    public record ClientOrderResponseDto(long Id,
                                         string? Observation,
                                         List<ProductDto> products,
                                         int TableId,
                                         long OrderId,
                                         StatusEnum status
                                         )
    {
    }
}
