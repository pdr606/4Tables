using System.ComponentModel.DataAnnotations;

namespace _4Tables.Application.Controllers.Ingredient.Dto
{
    public record CreateIngredientDto(

         [Required(ErrorMessage = "O nome é obrigatório!")]
         string name,
         bool available=true);
}
