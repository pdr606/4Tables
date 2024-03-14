
using _4Tables.Domain.Base.Repositories;
using _4Tables.Domain.Entities.Product;

namespace _4Tables.Domain.Repositories.Product
{
    public interface IProductRepository : IDomainRepository<ProductEntity>
        
    {
        Task<bool> Delete(long id);
        Task<bool> FindByName(string name);
        Task<List<ProductEntity>> FindAll();
        Task<ProductEntity> FindById(long id);
        Task<List<ProductEntity>> FindAllDisables();
        Task<bool> ActiveDesactive(long id);
        Task<List<ProductEntity>> FindAllWithId(List<long> ids);
    }
}
