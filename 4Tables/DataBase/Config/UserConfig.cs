using _4Tables.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4Tables.DataBase.Config
{
    public class UserConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email).IsRequired(true);

            builder.Property(x => x.FirstName).IsRequired(true);

            builder.Property(x => x.LastName).IsRequired(true);

            builder.Property(x => x.Password).IsRequired(true);

        }
    }
}
