namespace _4Tables.Application.Controllers.Order.Dto
{
    public record OrderListResponseDto(long id,
                                       int tableId,
                                       string total,
                                       string startTime
        );
}
