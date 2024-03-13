using _4Tables.Application.Controllers.User.Dto;
using _4Tables.Domain.Entities.User;

namespace _4Tables.Application.Controllers.User.Adapter
{
    public partial class UserAdapter
    {

        internal static UserEntity toDomainModel(CreateUserDto dto)
        {
            return new UserEntity(dto.email,
                                  dto.firstName,
                                  dto.lastName,
                                  dto.password,
                                  dto.role
                                  );
        } 
    }
}
