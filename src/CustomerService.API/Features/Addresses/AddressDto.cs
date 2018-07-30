using CustomerService.Core.Models;
using System;

namespace CustomerService.API.Features.Addresses
{
    public class AddressDto
    {        
        public Guid AddressId { get; set; }
        
        public static AddressDto FromAddress(Address address)
            => new AddressDto
            {
                AddressId = address.AddressId,
            };
    }
}
