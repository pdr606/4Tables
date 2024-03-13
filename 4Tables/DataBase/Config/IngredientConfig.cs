using _4Tables.Domain.Entities.Ingredient;
using _4Tables.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4Tables.DataBase.Config
{
    public class IngredientConfig : IEntityTypeConfiguration<IngredientEntity>
    {
        public void Configure(EntityTypeBuilder<IngredientEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(true);

            builder.HasMany(x => x.Products).WithMany(x => x.Ingredients)
                 .UsingEntity<Dictionary<string, object>>(
                     "ProductIngredient",
                     x => x.HasOne<ProductEntity>()
                             .WithMany()
                             .HasForeignKey("ProductId")
                             .HasConstraintName("FK_ProductIngredient_ProductId")
                             .OnDelete(DeleteBehavior.Cascade)
                             ,
                     x => x.HasOne<IngredientEntity>()
                             .WithMany()
                             .HasForeignKey("IngredientId")
                             .HasConstraintName("FK_ProductIngredient_IngredientId")
                             .OnDelete(DeleteBehavior.Cascade)
                 );
        }
    }
}
