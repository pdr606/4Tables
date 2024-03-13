using _4Tables.Domain.Base.Entities;

namespace _4Tables.Domain.Entities.RestaurantSettings
{
    public class RestaurantSettingsEntity : BaseEntity
    {
        public long Id { get; private set; }
        public int TotalTables { get; private set; }

        public RestaurantSettingsEntity() { }

        public RestaurantSettingsEntity(int totalTables) {
            TotalTables = totalTables;
            AtivarDesativar(true);
        }

        public void UpdateTotalTables(int newTotalTables) {
            TotalTables = newTotalTables;
        }
    }
}
