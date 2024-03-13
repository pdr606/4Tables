using _4Tables.Domain.Base.Entities;
using _4Tables.Domain.Base.Enum;
using _4Tables.Domain.Entities.ClienteOder;
using _4Tables.Domain.Entities.Ingredient;
using _4Tables.Domain.Entities.Order;

namespace _4Tables.Domain.Entities.Product
{
    public class ProductEntity : BaseEntity
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string? Image { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public int Requests { get; private set; }
        public CategoryEnum Category { get; private set; }
        public ICollection<ClienteOrderEntity> ClientOrders{ get; set; } = new List<ClienteOrderEntity>();
        public ICollection<IngredientEntity>? Ingredients { get; set; } = new List<IngredientEntity>();
        public ProductEntity() { }

        public ProductEntity(string name,
                             decimal price,
                             string? image,
                             string description,
                             int requests,
                             bool available,
                             CategoryEnum category
                             )
        {
            Name = name;
            Price = price;
            Image = image;
            Description = description;
            Requests = requests;
            Category = category;

            AtivarDesativar(available);
        }

        public void BindingOrders(ICollection<ClienteOrderEntity> orders)
        {
            if(ClientOrders == null) ClientOrders = new List<ClienteOrderEntity>();

            foreach(ClienteOrderEntity order in orders)
            {
                ClientOrders.Add(order);
            }
        }

        public void BindingIngredient(ICollection<IngredientEntity> ingredients) {
            if (Ingredients == null) Ingredients = new List<IngredientEntity>();
           
            foreach (IngredientEntity ingredient in ingredients)
            {
                Ingredients.Add(ingredient);
            }
        }

        public ProductEntity ComId(long id)
        {
            Id = id;
            return this;
        }
    }
}
