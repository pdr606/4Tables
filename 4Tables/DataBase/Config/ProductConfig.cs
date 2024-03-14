using _4Tables.Domain.Entities.ClienteOder;
using _4Tables.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4Tables.DataBase.Config
{
    public class ProductConfig : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                    .IsRequired();

            builder.Property(x => x.Price)
                    .IsRequired();

            builder.Property(x => x.Image)
                    .IsRequired(false);

            builder.Property(x => x.Description)
                    .IsRequired(true);

            builder.HasMany(x => x.ClientOrders).WithMany(x => x.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductClientOrder",
                    x => x.HasOne<ClienteOrderEntity>()
                            .WithMany()
                            .HasForeignKey("ClientOrderId")
                            .HasConstraintName("FK_ProductClientOrder_ClientOrdertId")
                            .OnDelete(DeleteBehavior.Cascade)
                            ,
                    x => x.HasOne<ProductEntity>()
                            .WithMany()
                            .HasForeignKey("ProductId")
                            .HasConstraintName("FK_ProductClientOrder_ProductId")
                            .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}
