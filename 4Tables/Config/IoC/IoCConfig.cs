using _4Tables.Config.Auth;
using _4Tables.Domain.Repositories.ClientOrder;
using _4Tables.Domain.Repositories.Ingredient;
using _4Tables.Domain.Repositories.Order;
using _4Tables.Domain.Repositories.Product;
using _4Tables.Domain.Repositories.RestaurantSettings;
using _4Tables.Domain.Repositories.Table;
using _4Tables.Domain.Repositories.User;
using _4Tables.Domain.Services.ClientOrder;
using _4Tables.Domain.Services.Ingredient;
using _4Tables.Domain.Services.Order;
using _4Tables.Domain.Services.Product;
using _4Tables.Domain.Services.Restaurant;
using _4Tables.Domain.Services.Table;
using _4Tables.Domain.Services.User;

namespace _4Tables.Config.IoC
{
    public static class IoCConfig
    {

        public static void InversionOfControlConfig(this WebApplicationBuilder builder) {

            builder.Services.AddScoped<IIngredientService, IngredientService>();
            builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();

            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<ITableService, TableService>();
            builder.Services.AddScoped<ITableRepository, TableRepository>();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddScoped<IRestaurantSettingsService, RestaurantSettingsService>();
            builder.Services.AddScoped<IRestaurantSettingsRepository, RestaurantSettingsRepository>();

            builder.Services.AddScoped<IClienteOrderService, ClienteOrderService>();
            builder.Services.AddScoped<IClienteOrderRepository, ClientOrderRepository>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<ITokenService, TokenService>();
        }
    }
}
