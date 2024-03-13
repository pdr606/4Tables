using _4Tables.Domain.Entities.User.Enum;
using System.ComponentModel.DataAnnotations;

namespace _4Tables.Application.Controllers.User.Dto
{
    public record CreateUserDto(
                                [Required(ErrorMessage = "E-mail é obrigatório.")]
                                string email,
                                [Required(ErrorMessage = "Nome é obrigatório.")]
                                string firstName,
                                [Required(ErrorMessage = "Sobrenome é obrigatório.")]
                                string lastName,
                                [Required(ErrorMessage = "Nome de usuário obrigatório.")]
                                string username,
                                [Required(ErrorMessage = "Senha é obrigatório.")]
                                string password,
                                [Required(ErrorMessage = "Tipo do usuário é obrigatório.")]
                                Role role
                                );
}
