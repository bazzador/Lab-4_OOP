using System;
using System.Collections.Generic;

namespace OrderClasses
{
    public class OrderBuro : ICloneable, IComparable<OrderBuro>
    {
        private string _name;
        private List<Order> _orders;

        public OrderBuro(string name)
        {
            _name = name;
            _orders = new List<Order>();
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public List<Order>  Orders => _orders;
        public void AddOrder(Order order) => _orders.Add(order);
        public void DeleteOrder(Order order) => _orders.Remove(order);

        public object Clone()
        {
            var cloneBuro = new OrderBuro(_name);
            foreach(var order in _orders)
            {
                cloneBuro.AddOrder((Order)order.Clone());
            }
            return cloneBuro;
        }

        public int CompareTo(OrderBuro other)
        {
            return _name.CompareTo(other._name);
        }
        public override bool Equals(object obj)
        {
            if(obj is OrderBuro other)
            {
                return _name == other._name && _orders.Equals(other._orders);
            }
            return false;
        }
        public override int GetHashCode() => HashCode.Combine(_orders, _name.GetHashCode());
        public override string ToString() => $"{_name} {_orders.Count}";
    }
}
