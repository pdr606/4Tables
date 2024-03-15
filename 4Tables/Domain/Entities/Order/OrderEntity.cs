using _4Tables.Domain.Base.Entities;
using _4Tables.Domain.Entities.ClienteOder;
using _4Tables.Domain.Entities.Table;

namespace _4Tables.Domain.Entities.Order
{
    public class OrderEntity : BaseEntity
    {
        public long Id { get; private set; }
        public TableEntity Table { get; set; }
        public int TableId { get; private set; }
        public ICollection<ClienteOrderEntity> ClientProducts { get; private set; }
        public decimal Total { get; set; }
        public decimal? PriceWithGarcomFee { get; set; }
        public decimal? Discount { get; set; }

        public OrderEntity() { }

        public OrderEntity(int tableId)
        {
            AtivarDesativar(true);
            TableId = tableId;
        }

        public OrderEntity ID(long id)
        {
            Id = id;
            return this;
        }

        public void BindingClienteOrder(ClienteOrderEntity clientOrder)
        {
            if (ClientProducts == null) ClientProducts = new List<ClienteOrderEntity>();
            
            ClientProducts.Add(clientOrder);
        }

        public void BindingTable(TableEntity table)
        {
            Table = table;
        }

        public void CalculatePartialTotal()
        {
            decimal total = 0;

            foreach(var item in ClientProducts)
            {
                foreach (var product in item.Products)
                {
                    total += product.Price;
                }
            }
            Total = total;
        }

    }
}
