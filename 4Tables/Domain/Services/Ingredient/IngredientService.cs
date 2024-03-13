using _4Tables.Application.Controllers.Ingredient.Adapter;
using _4Tables.Application.Controllers.Ingredient.Dto;
using _4Tables.Domain.Base.Common;
using _4Tables.Domain.Entities.Ingredient;
using _4Tables.Domain.Repositories.Ingredient;

namespace _4Tables.Domain.Services.Ingredient
{
    public class IngredientService : IIngredientService
    {

        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task<BasicResultT<IEnumerable<string>>> AddRange(List<CreateIngredientDto> dtos)
        {
            List<CreateIngredientDto> dtosFilterName = new List<CreateIngredientDto>();
            List<string> invalids = [];

            foreach(var dto in dtos)
            {
                var exist = await _ingredientRepository.FindByName(dto.name.ToUpper());

                if (!exist && !dtosFilterName.Contains(dto)) dtosFilterName.Add(dto);
                else if(!dtosFilterName.Contains(dto)) invalids.Add(dto.name);
            }

            await _ingredientRepository.AddRange(IngredientAdapter.ToDomainModelList(dtosFilterName));

            BasicResultT<IEnumerable<string>> result = new BasicResultT<IEnumerable<string>>();
            result.BindingData(invalids);
            return result;
        }

        public async Task<BasicResult> Delete(long id)
        {
            var success = await _ingredientRepository.Delete(id);
            var result = new BasicResult().ISSUCESS(success);

            if (result.IsFailure)
            {
                return result.ERROR(new Error(System.Net.HttpStatusCode.NotFound, $"Ingrediente com Id {id} não encontrado."));
            }

            return result;
        }

        public async Task<BasicResultT<List<IngredientDto>>> FindAll()
        {
            var list = await _ingredientRepository.FindAll();
            var dtoList = IngredientAdapter.toDtoList(list);

            var result = new BasicResultT<List<IngredientDto>>()
            {
                Data = dtoList,
            };

            result.ISSUCESS(true);

            return result;
        }

        public async Task<BasicResultT<IngredientDto>> FindById(long id)
        {
            var entity = await _ingredientRepository.FindById(id);

            var result = new BasicResultT<IngredientDto>();

            if (entity is null)
            {
                result.ISSUCESS(false).ERROR(new Error(System.Net.HttpStatusCode.NotFound, $"Ingrediente com Id {id} não encontrado."));
                return result;
            }

            result.BindingData(IngredientAdapter.toDto(entity));
            return result;
        }

        public async Task<IngredientEntity> FindByIdReturnsEntity(long id)
        {
            return await _ingredientRepository.FindById(id);
        }

        public async Task<List<IngredientEntity>> ValidateIngredientsId(List<long> ids)
        {
            List<IngredientEntity> validIngredients = new List<IngredientEntity>();
            foreach (var ingredientId in ids)
            {
                var ingredient = await FindByIdReturnsEntity(ingredientId);
                if (ingredient != null)
                {
                    validIngredients.Add(ingredient);
                }
            }

            return validIngredients;
        }
    }
}
