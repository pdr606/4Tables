using _4Tables.DataBase.Data;
using _4Tables.Domain.Base.Repositories;
using _4Tables.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace _4Tables.Domain.Repositories.Product
{
    public class ProductRepository : DomainRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<bool> ActiveDesactive(long id)
        {
            var entity = await _db.Set<ProductEntity>()
                                  .FirstOrDefaultAsync(x => x.Id == id);

            if(entity == null) {
                return false;            
            }

            entity.AtivarDesativar(!entity.Available);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(long id)
        {
            var entity = await _db.
                Set<ProductEntity>()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                entity.AtivarDesativar(false);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<List<ProductEntity>> FindAll()
        {
            return await _db.Set<ProductEntity>()
                            .Where(x => x.Available)
                            .Include(x => x.Ingredients)
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<List<ProductEntity>> FindAllDisables()
        {
            return await _db.Set<ProductEntity>()
                             .Where(x => !x.Available)
                             .AsNoTracking()
                             .ToListAsync();
        }

        public async Task<ProductEntity> FindById(long id)
        {
            return await _db.Set<ProductEntity>()
                            .Where(x => x.Available)
                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> FindByName(string name)
        {
            var entity = await _db.Set<ProductEntity>()
                                    .FirstOrDefaultAsync(x => x.Name == name);

            if (entity != null) return true;
            return false;
        }
    }

}
