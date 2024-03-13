using _4Tables.Application.Controllers.User.Dto;
using _4Tables.Domain.Base.Common;
using _4Tables.Domain.Base.Services;
using _4Tables.Domain.Entities.User;

namespace _4Tables.Domain.Services.User
{
    public interface IUserService : IDomainService<UserEntity>
    {
        public Task<BasicResult> Add(CreateUserDto dto);
        public Task<bool> ExistUser(string email);
        public Task<UserEntity> FindEntityByEmail(string email);
        public Task<BasicResultT<IEnumerable<UserListDto>>> FindAll();
        public bool ValidateCredentials(string loginPassword, string userPassword, string loginEmail, string userEmail);
        
    }
}
