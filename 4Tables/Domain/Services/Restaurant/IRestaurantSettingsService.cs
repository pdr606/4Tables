using _4Tables.Domain.Base.Common;
using _4Tables.Domain.Base.Services;
using _4Tables.Domain.Entities.RestaurantSettings;

namespace _4Tables.Domain.Services.Restaurant
{
    public interface IRestaurantSettingsService : IDomainService<RestaurantSettingsEntity>
    {

        Task Add(int tables);
        Task<int> TotalTables();
    }
}
