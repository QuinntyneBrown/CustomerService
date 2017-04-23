using MediatR;
using CustomerService.Data;
using CustomerService.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using CustomerService.Data.Model;

namespace CustomerService.Features.Customers
{
    public class CreateCustomerIfDoesNotExistCommand
    {
        public class CreateCustomerIfDoesNotExistRequest : IRequest<CreateCustomerIfDoesNotExistResponse>
        {
            public Guid TenantUniqueId { get; set; }
            public string Email { get; set; }
        }

        public class CreateCustomerIfDoesNotExistResponse { }

        public class CreateCustomerIfDoesNotExistHandler : IAsyncRequestHandler<CreateCustomerIfDoesNotExistRequest, CreateCustomerIfDoesNotExistResponse>
        {
            public CreateCustomerIfDoesNotExistHandler(CustomerServiceContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<CreateCustomerIfDoesNotExistResponse> Handle(CreateCustomerIfDoesNotExistRequest request)
            {
                var entity = await _context.Customers
                    .Include(x => x.Tenant)
                    .SingleOrDefaultAsync(x => x.EmailAddress == request.Email && x.Tenant.UniqueId == request.TenantUniqueId);

                if (entity != null)
                    return new CreateCustomerIfDoesNotExistResponse();

                var tenant = await _context.Tenants.SingleAsync(x => x.UniqueId == request.TenantUniqueId);

                _context.Customers.Add(entity = new Customer() { TenantId = tenant.Id, EmailAddress = request.Email });

                await _context.SaveChangesAsync();

                return new CreateCustomerIfDoesNotExistResponse();
            }

            private readonly CustomerServiceContext _context;
            private readonly ICache _cache;
        }

    }

}
