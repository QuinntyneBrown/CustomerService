using MediatR;
using CustomerService.Data;
using CustomerService.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace CustomerService.Features.Customers
{
    public class GetCustomersQuery
    {
        public class GetCustomersRequest : IRequest<GetCustomersResponse> { 
            public Guid TenantUniqueId { get; set; }       
        }

        public class GetCustomersResponse
        {
            public ICollection<CustomerApiModel> Customers { get; set; } = new HashSet<CustomerApiModel>();
        }

        public class GetCustomersHandler : IAsyncRequestHandler<GetCustomersRequest, GetCustomersResponse>
        {
            public GetCustomersHandler(CustomerServiceContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetCustomersResponse> Handle(GetCustomersRequest request)
            {
                var customers = await _context.Customers
                    .Include(x => x.Tenant)
                    .Where(x => x.Tenant.UniqueId == request.TenantUniqueId )
                    .ToListAsync();

                return new GetCustomersResponse()
                {
                    Customers = customers.Select(x => CustomerApiModel.FromCustomer(x)).ToList()
                };
            }

            private readonly CustomerServiceContext _context;
            private readonly ICache _cache;
        }

    }

}
