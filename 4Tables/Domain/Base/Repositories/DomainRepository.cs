using _4Tables.DataBase.Data;
using _4Tables.Domain.Base.Entities;

namespace _4Tables.Domain.Base.Repositories
{
    public class DomainRepository<T> : IDomainRepository<T> where T : BaseEntity
    {

        protected readonly ApplicationDbContext _db;

        public DomainRepository(ApplicationDbContext db) {  _db = db; }

     
        public async Task Add(T entity)
        {
            _db.
                Set<T>()
                .Add(entity);

            await _db.SaveChangesAsync();
        }

    }
}
