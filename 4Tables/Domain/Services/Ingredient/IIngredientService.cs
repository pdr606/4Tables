using _4Tables.Application.Controllers.Ingredient.Dto;
using _4Tables.Domain.Base.Common;
using _4Tables.Domain.Base.Services;
using _4Tables.Domain.Entities.Ingredient;

namespace _4Tables.Domain.Services.Ingredient
{
    public interface IIngredientService : IDomainService<IngredientEntity>
    {
        public Task<BasicResultT<IEnumerable<string>>> AddRange(List<CreateIngredientDto> dtos);
        public Task<BasicResult> Delete(long id);
        public Task<BasicResultT<List<IngredientDto>>> FindAll();
        public Task<BasicResultT<IngredientDto>> FindById(long id);
        public Task<IngredientEntity> FindByIdReturnsEntity(long id);
        public Task<List<IngredientEntity>> ValidateIngredientsId(List<long> ids);
    }
}
