using _4Tables.Domain.Entities.RestaurantSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4Tables.DataBase.Config
{
    public class RestaurantSettingsConfig : IEntityTypeConfiguration<RestaurantSettingsEntity>
    {
        public void Configure(EntityTypeBuilder<RestaurantSettingsEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TotalTables).IsRequired();
        }
    }
}
