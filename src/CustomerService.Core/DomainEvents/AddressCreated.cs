using System;

namespace CustomerService.Core.DomainEvents
{
    public class AddressCreated: DomainEvent
    {
        public AddressCreated(Guid addressId)
        {
            AddressId = addressId;
        }

        public Guid AddressId { get; set; }
    }
}
