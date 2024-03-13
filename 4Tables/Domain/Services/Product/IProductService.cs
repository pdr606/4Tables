using _4Tables.Application.Controllers.Product.Dto;
using _4Tables.Domain.Base.Common;
using _4Tables.Domain.Base.Services;
using _4Tables.Domain.Entities.Product;

namespace _4Tables.Domain.Services.Product
{
    public interface IProductService : IDomainService<ProductEntity>
    {
        public Task<BasicResult> Add(CreateProductDto dto);
        public Task<BasicResultT<List<ProductDto>>> FindAll();
        public  Task<BasicResultT<List<ProductDto>>> FindAllDisables();
        public Task<BasicResultT<ProductDto>> FindById(long id);
        public Task<BasicResult> Delete(long id);
        public Task<BasicResult> ActiveDesactive(long id);
    }
}
