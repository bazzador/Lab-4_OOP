using System;

namespace OrderClasses
{
    public class Client : ICloneable, IComparable<Client>
    {
        private ServiceType _serviceType;
        private string _address;

        public Client(ServiceType serviceType, string address)
        {
            _serviceType = serviceType;
            _address = address;
        }
        public ServiceType ServiceType_
        {
            get => _serviceType; 
            set => _serviceType = value; 
        }
        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public object Clone() => new Client(_serviceType, _address);
        public int CompareTo(Client other)
        {
            if(other == null) return 1;
            int serviceTypeComparison = _serviceType.CompareTo(other._serviceType);
            if(serviceTypeComparison != 0)
            {
                return serviceTypeComparison;
            }
                return _address.CompareTo(other._address);
        }
        public override bool Equals(object obj)
        {
            if(obj is Client other)
            {
                return _serviceType == other._serviceType &&
                    _address == other._address;
            }
            return false;
        }
        public override int GetHashCode() => HashCode.Combine(_serviceType, _address);
        public override string ToString() => $"|{_serviceType} => {_address}|";
    }
}
