using _4Tables.DataBase.Data;
using _4Tables.Domain.Base.Repositories;
using _4Tables.Domain.Entities.Ingredient;
using Microsoft.EntityFrameworkCore;

namespace _4Tables.Domain.Repositories.Ingredient
{
    public class IngredientRepository : DomainRepository<IngredientEntity>, IIngredientRepository
    {
        public IngredientRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task AddRange(List<IngredientEntity> entities)
        {
            await _db.Set<IngredientEntity>()
                     .AddRangeAsync(entities);

            await _db.SaveChangesAsync();
        }

        public async Task<bool> Delete(long id)
        {
            var entity = await _db.
                Set<IngredientEntity>()
                .FirstOrDefaultAsync(x => x.Id == id);

            if(entity != null)
            {
                entity.AtivarDesativar(false);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<List<IngredientEntity>> FindAll()
        {
            return await _db.Set<IngredientEntity>()
                            .Where(x => x.Available)
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<IngredientEntity> FindById(long id)
        {
            return await _db.Set<IngredientEntity>().FirstOrDefaultAsync(x => x.Id == id && x.Available);
        }

        public async Task<bool> FindByName(string name)
        {
            var ingredient = await _db.Set<IngredientEntity>()
                                       .FirstOrDefaultAsync(x => x.Name == name && x.Available);

            if(ingredient == null)
            {
                return false;
            }
            return true;
        }
    }
}
