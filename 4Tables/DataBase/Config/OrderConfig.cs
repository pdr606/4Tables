using _4Tables.Domain.Entities.ClienteOder;
using _4Tables.Domain.Entities.Order;
using _4Tables.Domain.Entities.Product;
using _4Tables.Domain.Entities.Table;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4Tables.DataBase.Config
{
    public class OrderConfig : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Table)
                    .WithOne(x => x.Order)
                    .HasForeignKey<TableEntity>(x => x.OrderId)
                    .IsRequired();

            builder.HasMany(x => x.ClientProducts)
                    .WithOne(x => x.Order)
                    .HasForeignKey(x => x.OrderId)
                    .IsRequired();
        }
    }
}
