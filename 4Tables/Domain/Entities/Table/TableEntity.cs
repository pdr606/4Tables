using _4Tables.Domain.Base.Entities;
using _4Tables.Domain.Entities.ClienteOder;
using _4Tables.Domain.Entities.Order;

namespace _4Tables.Domain.Entities.Table
{
    public class TableEntity : BaseEntity
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public OrderEntity Order { get; set; }
        public long OrderId { get; set; }
        public ClienteOrderEntity ClienteOrder { get; set; }
        public long ClienteOrderId { get; set; }

        public TableEntity() { }

        public TableEntity(int number, long orderId)
        {
            Number = number;
            OrderId = orderId;
        }

        public TableEntity ID(long id)
        {
            Id = id;
            return this;
        }

    }
}
