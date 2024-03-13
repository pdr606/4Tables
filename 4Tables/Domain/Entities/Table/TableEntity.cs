using _4Tables.Domain.Base.Entities;
using _4Tables.Domain.Entities.Order;

namespace _4Tables.Domain.Entities.Table
{
    public class TableEntity : BaseEntity
    {
        public long Id { get; set; }
        public decimal Price { get; set; }
        public decimal PriceWithGarcomFee { get; set; }
        public int Number { get; set; }
        public OrderEntity Order { get; set; }
        public long OrderId { get; set; }

        public TableEntity() { }

        public TableEntity(decimal price, int number, long orderId)
        {
            Price = price;
            Number = number;
            OrderId = orderId;
        }

        public TableEntity ID(long id)
        {
            Id = id;
            return this;
        }

        public TableEntity PRICEWITHGARCOMFEE(decimal priceWithGarcomFee)
        {
            PriceWithGarcomFee = priceWithGarcomFee;
            return this;
        }
    }
}
