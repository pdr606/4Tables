namespace _4Tables.Application.Controllers.Order.Dto
{
    public record ClientOrderDto(string? observation,
                                 List<long> productsId,
                                 long? OrderId
        )
    {
    }
}
