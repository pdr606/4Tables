using _4Tables.Domain.Entities.User;

namespace _4Tables.Config.Auth
{
    public interface ITokenService
    {
        string GenerateToken(UserEntity user);
    }
}
