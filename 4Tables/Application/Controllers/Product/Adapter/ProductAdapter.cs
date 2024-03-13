using _4Tables.Application.Controllers.Ingredient.Adapter;
using _4Tables.Application.Controllers.Product.Dto;
using _4Tables.Domain.Entities.Product;

namespace _4Tables.Application.Controllers.Product.Adapter
{
    public partial class ProductAdapter
    {

        internal static ProductEntity ToDomainModel(CreateProductDto dto)
        {
            return new ProductEntity(dto.name,
                                     decimal.Parse(dto.price),
                                     dto.image,
                                     dto.description,
                                     0,
                                     true,
                                     dto.category
                    );
        }

        internal static ProductDto ToDto(ProductEntity entity) {

            return new ProductDto(entity.Id,
                                  entity.Name,
                                  entity.Price.ToString().Replace('.', ','),
                                  entity.Image ?? "",
                                  entity.Description,
                                  entity.Requests,
                                  entity.Available,
                                  entity.Category,
                                  IngredientAdapter.toDtoList(entity.Ingredients));
        }

        internal static List<ProductDto> ToDtoList(List<ProductEntity> entities)
        {
            List<ProductDto> res = new List<ProductDto>();

            foreach (var entity in entities)
            {
                res.Add(ToDto(entity));
            }
            return res;
        }
    }
}
