using _4Tables.Domain.Base.Common;
using _4Tables.Domain.Entities.RestaurantSettings;
using _4Tables.Domain.Repositories.RestaurantSettings;

namespace _4Tables.Domain.Services.Restaurant
{
    public class RestaurantSettingsService : IRestaurantSettingsService
    {

        private readonly IRestaurantSettingsRepository _restaurantSettingsRepository;

        public RestaurantSettingsService(IRestaurantSettingsRepository restaurantSettingsRepository)
        {
            _restaurantSettingsRepository = restaurantSettingsRepository;
        }

        public async Task Add(int Totaltables)
        {

            var totalTables = await _restaurantSettingsRepository.ConsultTotalTables();

            if(totalTables == -1)
            {
                await _restaurantSettingsRepository.Add(new RestaurantSettingsEntity(Totaltables));
                return;
            }

            await _restaurantSettingsRepository.UpdateTotalTables(Totaltables);

        }
    }
}
