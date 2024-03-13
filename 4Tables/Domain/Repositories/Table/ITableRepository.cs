using _4Tables.Domain.Base.Repositories;
using _4Tables.Domain.Entities.Table;

namespace _4Tables.Domain.Repositories.Table
{
    public interface ITableRepository : IDomainRepository<TableEntity>
    {
        Task<bool> Delete(long id);
    }
}
