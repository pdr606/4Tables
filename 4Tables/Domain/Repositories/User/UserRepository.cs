using _4Tables.DataBase.Data;
using _4Tables.Domain.Base.Repositories;
using _4Tables.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace _4Tables.Domain.Repositories.User
{
    public class UserRepository : DomainRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<bool> ExistUserByEmail(string email)
        {
            var entity = await _db.Set<UserEntity>().FirstOrDefaultAsync(x => x.Email == email);
            if(entity == null)
            {
                return false;
            }
            return true;
        }

        public async Task<UserEntity> FindUserEntityByEmail(string email)
        {
            return await _db.Set<UserEntity>().FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
