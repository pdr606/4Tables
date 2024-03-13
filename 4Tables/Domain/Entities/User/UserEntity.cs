using _4Tables.Domain.Base.Entities;
using _4Tables.Domain.Entities.User.Enum;

namespace _4Tables.Domain.Entities.User
{
    public class UserEntity : BaseEntity

    {
        public Guid Id{ get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; }

        public UserEntity() { }

        public UserEntity(string email,
                          string firstName,
                          string lastName,
                          string paswword,
                          Role role)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = paswword;
            Role = role;
        }

         public void Modify(UserEntity entity)
        {
            Email = entity.Email;
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            Password = entity.Password;
            Role = entity.Role;
        }

        public void AddPasswordHash(string password)
        {
            Password = password;
        }
    }
}
