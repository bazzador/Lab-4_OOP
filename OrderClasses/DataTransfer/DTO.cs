using System;
using System.Collections.Generic;

namespace OrderClasses.DataTransfer
{
    public class PerformerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    public class ClientDTO
    {
        public ServiceType ServiceType { get; set; }
        public string Address { get; set; }
    }
    public class OrderDTO
    {
        public PerformerDTO Performer { get; set; }
        public ClientDTO Client { get; set; }
        public DateTime Date { get; set; }
    }
    public class OrderBuroDTO
    {
        public string Name { get; set; }
        public List<OrderDTO> Orders { get; set; }
    }
}
