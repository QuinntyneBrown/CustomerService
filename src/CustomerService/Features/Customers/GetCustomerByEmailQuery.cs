using MediatR;
using CustomerService.Data;
using CustomerService.Features.Core;
using System;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CustomerService.Features.Customers
{
    public class GetCustomerByEmailQuery
    {
        public class GetCustomerByEmailRequest : IRequest<GetCustomerByEmailResponse>
        {
            public Guid TenantUniqueId { get; set; }
            public string Email { get; set; }
        }

        public class GetCustomerByEmailResponse
        {
            public CustomerApiModel Customer { get; set; }
        }

        public class GetCustomerByEmailHandler : IAsyncRequestHandler<GetCustomerByEmailRequest, GetCustomerByEmailResponse>
        {
            public GetCustomerByEmailHandler(CustomerServiceContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetCustomerByEmailResponse> Handle(GetCustomerByEmailRequest request)
            {
                return new GetCustomerByEmailResponse()
                {
                    Customer = CustomerApiModel.FromCustomer(await _context.Customers
                    .Include(x => x.Tenant)
                    .SingleAsync(x => x.EmailAddress == request.Email && x.Tenant.UniqueId == request.TenantUniqueId))
                };
            }

            private readonly CustomerServiceContext _context;
            private readonly ICache _cache;
        }

    }

}
