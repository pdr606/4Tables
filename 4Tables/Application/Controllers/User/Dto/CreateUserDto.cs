using _4Tables.Domain.Entities.User.Enum;

namespace _4Tables.Application.Controllers.User.Dto
{
    public record CreateUserDto(string email,
                                string firstName,
                                string lastName,
                                string username,
                                string password,
                                Role role
                                );
}
