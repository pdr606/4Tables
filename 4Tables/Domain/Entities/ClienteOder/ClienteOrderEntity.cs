using _4Tables.Domain.Base.Entities;
using _4Tables.Domain.Base.Enum;
using _4Tables.Domain.Entities.Order;
using _4Tables.Domain.Entities.Product;

namespace _4Tables.Domain.Entities.ClienteOder
{
    public class ClienteOrderEntity : BaseEntity
    {
        public long Id { get; private set; }
        public string? Observation { get; set; } = string.Empty;
        public ICollection<ProductEntity> Products{ get; set; }
        public OrderEntity Order{ get; set; }
        public long? OrderId { get; set; }
        public StatusEnum Status{ get; private set; }

        public ClienteOrderEntity() { }

        public ClienteOrderEntity(string? observation)
        {
            Observation = observation;
        }

        public ClienteOrderEntity WITHSTATUS(StatusEnum status)
        {
            Status = status;
            return this;
        }

        public ClienteOrderEntity ID(long id)
        {
            Id = id;
            return this;
        }

        public ClienteOrderEntity WITHORDERID(long? id)
        {
            OrderId = id;
            return this;
        }

        public void BindingProducts(List<ProductEntity> products)
        {
            if(Products == null) Products = new List<ProductEntity>();

            foreach (ProductEntity product in products)
            {
                Products.Add(product);
            }
        }
    }
}
