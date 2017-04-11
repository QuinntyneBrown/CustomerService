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
    public class RegisterCustomerCommand
    {
        public class RegisterCustomerRequest : IRequest<RegisterCustomerResponse>
        {
            public Guid TenantUniqueId { get; set; }
        }

        public class RegisterCustomerResponse
        {
            public RegisterCustomerResponse()
            {

            }
        }

        public class RegisterCustomerHandler : IAsyncRequestHandler<RegisterCustomerRequest, RegisterCustomerResponse>
        {
            public RegisterCustomerHandler(CustomerServiceContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RegisterCustomerResponse> Handle(RegisterCustomerRequest request)
            {
                throw new System.NotImplementedException();
            }

            private readonly CustomerServiceContext _context;
            private readonly ICache _cache;
        }

    }

}
