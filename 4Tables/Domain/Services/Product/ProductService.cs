using _4Tables.Application.Controllers.Product.Adapter;
using _4Tables.Application.Controllers.Product.Dto;
using _4Tables.Domain.Base.Common;
using _4Tables.Domain.Repositories.Product;
using _4Tables.Domain.Services.Ingredient;

namespace _4Tables.Domain.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IIngredientService _ingredientService;

        public ProductService(IProductRepository repository, IIngredientService ingredientService)
        {
            _productRepository = repository;
            _ingredientService = ingredientService;
        }

        public async Task<BasicResult> Add(CreateProductDto dto)
        {
            var exist = await _productRepository.FindByName(dto.name);
            BasicResult result = new BasicResult();

            if (exist)
            {
                result.ERROR(new Error(System.Net.HttpStatusCode.Conflict, "Produto já cadastrado."));
                result.ISSUCESS(false);
                return result;
            }

            var entity = ProductAdapter.ToDomainModel(dto);
            var ingredients = await _ingredientService.ValidateIngredientsId(dto.ingredientsId);

            entity.BindingIngredient(ingredients);

            await _productRepository.Add(entity);
            result.ISSUCESS(true);
            return result;
        }

        public async Task<BasicResultT<List<ProductDto>>> FindAll()
        {
            var entityList = await _productRepository.FindAll();

            var res = ProductAdapter.ToDtoList(entityList);

            BasicResultT<List<ProductDto>> result = new BasicResultT<List<ProductDto>>();

            result.BindingData(res);
            result.ISSUCESS(true);

            return result;

        }
        public async Task<BasicResultT<List<ProductDto>>> FindAllDisables()
        {
            var entityList = await _productRepository.FindAllDisables();

            var res = ProductAdapter.ToDtoList(entityList);

            BasicResultT<List<ProductDto>> result = new BasicResultT<List<ProductDto>>();

            result.BindingData(res);
            result.ISSUCESS(true);

            return result;
        }

        public async Task<BasicResultT<ProductDto>> FindById(long id)
        {
            var entity = await _productRepository.FindById(id);

            var result = new BasicResultT<ProductDto>();

            if (entity is null)
            {
                result.ISSUCESS(false).ERROR(new Error(System.Net.HttpStatusCode.NotFound, $"Produto com Id {id} não encontrado."));
                return result;
            }

            result.BindingData(ProductAdapter.ToDto(entity));
            return result;
        }

        public async Task<BasicResult> Delete(long id)
        {
            var success = await _productRepository.Delete(id);
            var result = new BasicResult().ISSUCESS(success);

            if (result.IsFailure)
            {
                return result.ERROR(new Error(System.Net.HttpStatusCode.NotFound, $"Produto com Id {id} não encontrado."));
            }

            return result;
        }

        public async Task<BasicResult> ActiveDesactive(long id)
        {
            BasicResult result = new BasicResult();
            var succes = await _productRepository.ActiveDesactive(id);

            result.ISSUCESS(succes);

            if (!succes)
            {
                result.ERROR(new Error(System.Net.HttpStatusCode.NotFound, $"Produto com Id {id} nao encontrado."));
                return result;
            }


            return result;

        }
    }
}
