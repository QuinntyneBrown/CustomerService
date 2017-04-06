using MediatR;
using CustomerService.Data;
using CustomerService.Data.Model;
using CustomerService.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace CustomerService.Features.Customers
{
    public class RemoveCustomerCommand
    {
        public class RemoveCustomerRequest : IRequest<RemoveCustomerResponse>
        {
            public int Id { get; set; }
            public Guid TenantUniqueId { get; set; } 
        }

        public class RemoveCustomerResponse { }

        public class RemoveCustomerHandler : IAsyncRequestHandler<RemoveCustomerRequest, RemoveCustomerResponse>
        {
            public RemoveCustomerHandler(CustomerServiceContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveCustomerResponse> Handle(RemoveCustomerRequest request)
            {
                var customer = await _context.Customers.SingleAsync(x=>x.Id == request.Id && x.Tenant.UniqueId == request.TenantUniqueId);
                customer.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveCustomerResponse();
            }

            private readonly CustomerServiceContext _context;
            private readonly ICache _cache;
        }
    }
}
