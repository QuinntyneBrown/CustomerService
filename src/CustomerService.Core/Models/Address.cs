using CustomerService.Core.Common;
using CustomerService.Core.DomainEvents;
using System;

namespace CustomerService.Core.Models
{
    public class Address: AggregateRoot
    {
        public Address()
            => Apply(new AddressCreated(AddressId));

        public Guid AddressId { get; set; } = Guid.NewGuid();          
        public string Name { get; set; }        
        public bool IsDeleted { get; set; }

        protected override void EnsureValidState()
        {
            
        }

        protected override void When(DomainEvent @event)
        {
            switch (@event)
            {
                case AddressCreated addressCreated:
                    AddressId = addressCreated.AddressId;
                    break;
                    
                case AddressRemoved addressRemoved:
                    IsDeleted = true;
                    break;
            }
        }

        public void Remove()
            => Apply(new AddressRemoved());
    }
}
