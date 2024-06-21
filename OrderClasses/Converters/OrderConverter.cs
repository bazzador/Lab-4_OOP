using OrderClasses.DataTransfer;

namespace OrderClasses.Converters
{
    public class OrderConverter
    {
        public static OrderDTO ToDTO(Order order)
        {
            return new OrderDTO
            {
                Performer = PerformerConverter.ToDTO(order.Performer_),
                Client = ClientConverter.ToDTO(order.Client_),
                Date = order.Date
            };
        }
        public static Order FromDTO(OrderDTO dtoObj) => new Order(PerformerConverter.FromDTO(dtoObj.Performer), ClientConverter.FromDTO(dtoObj.Client), dtoObj.Date);
    }
}
