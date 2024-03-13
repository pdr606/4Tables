using _4Tables.Domain.Base.Entities;
using _4Tables.Domain.Entities.ClienteOder;
using _4Tables.Domain.Entities.Table;

namespace _4Tables.Domain.Entities.Order
{
    public class OrderEntity : BaseEntity
    {
        public long Id { get; private set; }
        public string Observation { get; set; } = string.Empty;
        public TableEntity Table { get; set; }
        public ICollection<ClienteOrderEntity> ClientProducts { get; private set; } = new List<ClienteOrderEntity>();

        public OrderEntity() { }

        public OrderEntity(bool available, string observation)
        {
            Observation = observation;
            AtivarDesativar(available);
        }

        public OrderEntity ID(long id)
        {
            Id = id;
            return this;
        }

        public void BindingProduct(ICollection<ClienteOrderEntity> products)
        {
            if (ClientProducts == null)
            {
                ClientProducts = new List<ClienteOrderEntity>();
            }

            foreach (ClienteOrderEntity product in products)
            {
                ClientProducts.Add(product);
            }
        }

        public void BindingTable(TableEntity table)
        {
            Table = table;
        }

    }
}
