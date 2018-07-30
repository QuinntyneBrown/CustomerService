using System;

namespace CustomerService.Core.DomainEvents
{
    public class CustomerCreated: DomainEvent
    {
        public CustomerCreated(string name, Guid customerId)
        {
             Name = name;
            CustomerId = customerId;
        }
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
    }
}
