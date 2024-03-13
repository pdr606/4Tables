using _4Tables.Domain.Base.Repositories;
using _4Tables.Domain.Entities.Ingredient;

namespace _4Tables.Domain.Repositories.Ingredient
{
    public interface IIngredientRepository : IDomainRepository<IngredientEntity>
    {
        Task<bool> Delete(long id);
        Task AddRange(List<IngredientEntity> entities);
        Task<List<IngredientEntity>> FindAll();
        Task<IngredientEntity> FindById(long id);
        Task<bool> FindByName(string name);
    }
}
