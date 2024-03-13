using _4Tables.Domain.Entities.Table;
using _4Tables.Domain.Repositories.Table;

namespace _4Tables.Domain.Services.Table
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public void Add(TableEntity entity)
        {
            _tableRepository.Add(entity);
        }

        public void Delete(long id)
        {
            _tableRepository.Delete(id);
        }
    }
}
