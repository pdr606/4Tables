using _4Tables.DataBase.Data;
using _4Tables.Domain.Base.Repositories;
using _4Tables.Domain.Entities.Product;
using _4Tables.Domain.Entities.Table;
using Microsoft.EntityFrameworkCore;

namespace _4Tables.Domain.Repositories.Table
{
    public class TableRepository : DomainRepository<TableEntity>, ITableRepository
    {
        public TableRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<bool> Delete(long id)
        {
            var entity = await _db.
                Set<TableEntity>()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                entity.AtivarDesativar(false);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;

        }
    }
}
