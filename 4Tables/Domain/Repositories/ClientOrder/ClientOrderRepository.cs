using _4Tables.DataBase.Data;
using _4Tables.Domain.Base.Repositories;
using _4Tables.Domain.Entities.ClienteOder;

namespace _4Tables.Domain.Repositories.ClientOrder
{
    public class ClientOrderRepository : DomainRepository<ClienteOrderEntity>, IClienteOrderRepository
    {
        public ClientOrderRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
