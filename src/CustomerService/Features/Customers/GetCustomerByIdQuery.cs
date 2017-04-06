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
    public class GetCustomerByIdQuery
    {
        public class GetCustomerByIdRequest : IRequest<GetCustomerByIdResponse> { 
            public int Id { get; set; }
            public Guid TenantUniqueId { get; set; }
        }

        public class GetCustomerByIdResponse
        {
            public CustomerApiModel Customer { get; set; } 
        }

        public class GetCustomerByIdHandler : IAsyncRequestHandler<GetCustomerByIdRequest, GetCustomerByIdResponse>
        {
            public GetCustomerByIdHandler(CustomerServiceContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetCustomerByIdResponse> Handle(GetCustomerByIdRequest request)
            {                
                return new GetCustomerByIdResponse()
                {
                    Customer = CustomerApiModel.FromCustomer(await _context.Customers
                    .Include(x => x.Tenant)				
					.SingleAsync(x=>x.Id == request.Id &&  x.Tenant.UniqueId == request.TenantUniqueId))
                };
            }

            private readonly CustomerServiceContext _context;
            private readonly ICache _cache;
        }

    }

}
