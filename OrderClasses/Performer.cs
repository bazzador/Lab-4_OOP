using System;

namespace OrderClasses
{
    public class Performer : ICloneable, IComparable<Performer>
    {
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;

        public Performer(string firstName, string lastName, DateTime dateOfBirth)
        {
            _firstName = firstName;
            _lastName = lastName;
            _dateOfBirth = dateOfBirth;
        }
        public string FirstName
        {
            get => _firstName; 
            set => _firstName = value; 
        }
        public string LastName
        {
            get => _lastName; 
            set => _lastName = value; 
        }
        public DateTime DateOfBirth
        {
            get => _dateOfBirth; 
            set => _dateOfBirth = value; 
        }

        public object Clone() => new Performer(_firstName, _lastName, _dateOfBirth);
        public int CompareTo(Performer other)
        {
            if (other == null)
            {
                return 1;
            }

            int lastNameComparison = _lastName.CompareTo(other._lastName);
            if (lastNameComparison != 0)
            {
                return lastNameComparison;
            }

            int firstNameComparison = _firstName.CompareTo(other._firstName);
            if (firstNameComparison != 0)
            {
                return firstNameComparison;
            }

            return _dateOfBirth.CompareTo(other._dateOfBirth);
        }
        public override bool Equals(object obj)
        {
            if(obj is Performer other)
            {
                return _firstName == other._firstName && _lastName == other._lastName && _dateOfBirth == other._dateOfBirth;
            }
            return false;
        }
        public override int GetHashCode() => HashCode.Combine(_firstName, _lastName, _dateOfBirth);
        public override string ToString() => $"|{_lastName} {_firstName}|";
    }
}
