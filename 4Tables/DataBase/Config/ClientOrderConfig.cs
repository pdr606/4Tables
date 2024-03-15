using _4Tables.Domain.Entities.ClienteOder;
using _4Tables.Domain.Entities.Table;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4Tables.DataBase.Config
{
    public class ClientOrderConfig : IEntityTypeConfiguration<ClienteOrderEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteOrderEntity> builder)
        {

            builder.HasOne(x => x.Table)
               .WithOne(x => x.ClienteOrder)
               .HasForeignKey<TableEntity>(x => x.ClienteOrderId)
               .IsRequired();
        }
    }
}
