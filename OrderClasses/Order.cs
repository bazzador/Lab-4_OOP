using System;

namespace OrderClasses
{
    public class Order : ICloneable, IComparable<Order>
    {
        private Performer _performer;
        private Client _client;
        private DateTime _date;
        public Order(Performer performer, Client client, DateTime date)
        {
            _performer = performer;
            _client = client;
            _date = date;
        }
        public Performer Performer_
        {
            get => _performer; 
            set => _performer = value; 
        }
        public Client Client_
        {
            get => _client;
            set => _client = value;
        }
        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }

        public object Clone() => new Order((Performer)_performer.Clone(), (Client)_client.Clone(), _date);
        public int CompareTo(Order other)
        {
            if (other == null) return 1;
            int performerComparison = _performer.CompareTo(other._performer);
            if (performerComparison != 0) 
                return performerComparison;
            int clientComparison = _client.CompareTo(other._client);   
            if (clientComparison != 0) 
                return clientComparison;
            return _date.CompareTo(other._date);
        }
        public override bool Equals(object obj)
        {
            if(obj is Order other)
            {
                return _performer.Equals(other._performer) && _client.Equals(other._client) && _date == other._date;
            }
            return false;
        }
        public override int GetHashCode() => HashCode.Combine(_performer, _client, _date);
        public override string ToString() => $"{_performer} {_client} {_date}|";
    }
}
