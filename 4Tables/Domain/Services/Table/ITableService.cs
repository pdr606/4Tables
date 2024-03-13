using _4Tables.Domain.Base.Services;
using _4Tables.Domain.Entities.Table;

namespace _4Tables.Domain.Services.Table
{
    public interface ITableService : IDomainService<TableEntity>
    {
        void Delete(long id);
    }
}
