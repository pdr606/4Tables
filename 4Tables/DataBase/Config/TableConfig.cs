using _4Tables.Domain.Entities.Table;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4Tables.DataBase.Config
{
    public class TableConfig : IEntityTypeConfiguration<TableEntity>
    {
        public void Configure(EntityTypeBuilder<TableEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Price)
                    .IsRequired();

            builder.Property(x => x.PriceWithGarcomFee)
                    .IsRequired();

            builder.Property(x => x.Number)
                    .IsRequired();

           
        }
    }
}
