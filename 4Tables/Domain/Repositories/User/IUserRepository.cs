using _4Tables.Domain.Base.Repositories;
using _4Tables.Domain.Entities.User;

namespace _4Tables.Domain.Repositories.User
{
    public interface IUserRepository : IDomainRepository<UserEntity>
    {

        Task<bool> ExistUserByEmail(string email);
        Task<UserEntity> FindUserEntityByEmail(string email);
        Task<IEnumerable<UserEntity>> FindAll();
    }
}
