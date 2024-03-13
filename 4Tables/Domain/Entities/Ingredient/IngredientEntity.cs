using _4Tables.Domain.Base.Entities;
using _4Tables.Domain.Entities.Product;

namespace _4Tables.Domain.Entities.Ingredient
{
    public class IngredientEntity : BaseEntity
    {

        public long Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public ICollection<ProductEntity> Products { get; private set; } = new List<ProductEntity>();
        public IngredientEntity() { }

        public IngredientEntity(string name, bool available)
        {
            Name = name;
            AtivarDesativar(available);
        }

        public IngredientEntity ID(long id)
        {
            Id = id; return this;
        }
    }
}
