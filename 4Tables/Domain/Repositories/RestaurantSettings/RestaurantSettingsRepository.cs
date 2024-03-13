using _4Tables.DataBase.Data;
using _4Tables.Domain.Base.Common;
using _4Tables.Domain.Base.Repositories;
using _4Tables.Domain.Entities.RestaurantSettings;
using Microsoft.EntityFrameworkCore;

namespace _4Tables.Domain.Repositories.RestaurantSettings
{
    public class RestaurantSettingsRepository : DomainRepository<RestaurantSettingsEntity> , IRestaurantSettingsRepository
    {
        public RestaurantSettingsRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<int> ConsultTotalTables()
        {
            var entity = await _db.Set<RestaurantSettingsEntity>().FirstOrDefaultAsync(x => x.Id == 1L);

            if(entity == null)
            {
                return -1;
            }

            return entity.TotalTables;
        }

        public async Task UpdateTotalTables(int totalTables)
        {
            var entity = await _db.Set<RestaurantSettingsEntity>().FirstOrDefaultAsync(x => x.Id == 1L);

            if(entity != null)
            {
                entity.UpdateTotalTables(totalTables);
                _db.Set<RestaurantSettingsEntity>().Update(entity);
                await _db.SaveChangesAsync();
            }
        }
    }
}
