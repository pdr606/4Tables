using _4Tables.Domain.Entities.Ingredient;
using _4Tables.Domain.Entities.Order;
using _4Tables.Domain.Entities.Product;
using _4Tables.Domain.Entities.RestaurantSettings;
using _4Tables.Domain.Entities.Table;
using _4Tables.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace _4Tables.DataBase.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        DbSet<ProductEntity> Products { get; set; }
        DbSet<IngredientEntity> Ingredients { get; set;}
        DbSet<TableEntity> Tables { get; set; }
        DbSet<OrderEntity> Orders { get; set; }
        DbSet<RestaurantSettingsEntity> Restaurants { get; set;}
        DbSet<UserEntity> Users { get; set; }
    }
}
