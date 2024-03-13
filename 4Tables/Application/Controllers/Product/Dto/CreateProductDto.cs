using _4Tables.Domain.Base.Enum;

namespace _4Tables.Application.Controllers.Product.Dto
{
    public record CreateProductDto(string name, string price, string? image, string description, CategoryEnum category, List<long> ingredientsId);
}
