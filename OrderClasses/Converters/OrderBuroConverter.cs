using OrderClasses.DataTransfer;
using System.Collections.Generic;

namespace OrderClasses.Converters
{
    public class OrderBuroConverter
    {
        public static OrderBuroDTO ToDTO (OrderBuro orderBuro)
        {
            var dtoObj = new OrderBuroDTO
            {
                Name = orderBuro.Name,
                Orders = new List<OrderDTO>()
            };
            foreach (var order in orderBuro.Orders)
            {
                dtoObj.Orders.Add(OrderConverter.ToDTO(order)); 
            }
            return dtoObj;
        }
        public static OrderBuro FromDTO (OrderBuroDTO dtoObj)
        {
            var orderBuro = new OrderBuro(dtoObj.Name);
            foreach(var orderDTO in dtoObj.Orders)
            {
                orderBuro.Orders.Add (OrderConverter.FromDTO(orderDTO)); 
            }
            return orderBuro;
        }
    }
}
