using _4Tables.Application.Controllers.Ingredient.Dto;
using _4Tables.Domain.Entities.Ingredient;

namespace _4Tables.Application.Controllers.Ingredient.Adapter
{
    public partial class IngredientAdapter
    {
        internal static IngredientEntity ToDomainModel(CreateIngredientDto dto)
        {
            return new IngredientEntity(dto.name.ToUpper(),
                                        dto.available);
        }

        internal static List<IngredientEntity> ToDomainModelList(List<CreateIngredientDto> entities) {
            
            List<IngredientEntity> res = new List<IngredientEntity>();

            foreach (var entity in entities)
            {
                entity.name.ToUpper();
                res.Add(ToDomainModel(entity));
            }

            return res;
        }

        internal static IngredientEntity ToDomainModel(IngredientDto dto)
        {
            return new IngredientEntity(dto.name,
                                        dto.available)
                                        .ID(dto.id);
        }

        internal static List<IngredientEntity> ToDomainModelList(List<IngredientDto> entities)
        {

            List<IngredientEntity> res = new List<IngredientEntity>();

            foreach (var entity in entities)
            {
                res.Add(ToDomainModel(entity));
            }

            return res;
        }

        internal static IngredientDto toDto(IngredientEntity entity)
        {
            return new IngredientDto(entity.Id,
                                     entity.Name,
                                     entity.Available);
        }

        internal static List<IngredientDto> toDtoList(List<IngredientEntity> entities)
        {
            List<IngredientDto> res = new List<IngredientDto>();

            foreach(var entity in entities)
            {
                res.Add(toDto(entity));
            }

            return res;
        }

        internal static List<IngredientDto> toDtoList(ICollection<IngredientEntity> entities)
        {
            List<IngredientDto> res = new List<IngredientDto>();

            foreach (var entity in entities)
            {
                res.Add(toDto(entity));
            }

            return res;
        }
    }
}
