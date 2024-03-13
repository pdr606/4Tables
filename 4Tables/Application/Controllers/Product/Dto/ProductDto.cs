using _4Tables.Application.Controllers.Ingredient.Dto;
using _4Tables.Domain.Base.Enum;

namespace _4Tables.Application.Controllers.Product.Dto
{
    public record ProductDto(long id,
                             string name,
                             string price,
                             string? image,
                             string description,
                             int requests,
                             bool available,
                             CategoryEnum category,
                             List<IngredientDto> Ingredients);
}
