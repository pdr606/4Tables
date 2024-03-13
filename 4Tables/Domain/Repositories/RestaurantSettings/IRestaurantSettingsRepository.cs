using _4Tables.Domain.Base.Repositories;
using _4Tables.Domain.Entities.RestaurantSettings;

namespace _4Tables.Domain.Repositories.RestaurantSettings
{
    public interface IRestaurantSettingsRepository : IDomainRepository<RestaurantSettingsEntity>
    {
        Task<int> ConsultTotalTables();
        Task UpdateTotalTables(int totalTables);
    }
}
