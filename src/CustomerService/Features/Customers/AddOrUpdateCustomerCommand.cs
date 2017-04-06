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
    public class AddOrUpdateCustomerCommand
    {
        public class AddOrUpdateCustomerRequest : IRequest<AddOrUpdateCustomerResponse>
        {
            public CustomerApiModel Customer { get; set; }
            public Guid TenantUniqueId { get; set; }
        }

        public class AddOrUpdateCustomerResponse { }

        public class AddOrUpdateCustomerHandler : IAsyncRequestHandler<AddOrUpdateCustomerRequest, AddOrUpdateCustomerResponse>
        {
            public AddOrUpdateCustomerHandler(CustomerServiceContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<AddOrUpdateCustomerResponse> Handle(AddOrUpdateCustomerRequest request)
            {
                var entity = await _context.Customers
                    .Include(x => x.Tenant)
                    .SingleOrDefaultAsync(x => x.Id == request.Customer.Id && x.Tenant.UniqueId == request.TenantUniqueId);
                
                if (entity == null) {
                    var tenant = await _context.Tenants.SingleAsync(x => x.UniqueId == request.TenantUniqueId);
                    _context.Customers.Add(entity = new Customer() { TenantId = tenant.Id });
                }

                entity.Name = request.Customer.Name;
                
                await _context.SaveChangesAsync();

                return new AddOrUpdateCustomerResponse();
            }

            private readonly CustomerServiceContext _context;
            private readonly ICache _cache;
        }

    }

}
