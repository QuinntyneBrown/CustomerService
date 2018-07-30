using CustomerService.Core.Interfaces;
using CustomerService.Core.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.API.Features.Addresses
{
    public class GetAddressesQuery
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public IEnumerable<AddressDto> Addresses { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEventStore _eventStore;

            public Handler(IEventStore eventStore) => _eventStore = eventStore;

            public Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => Task.FromResult(new Response()
                {
                    Addresses = _eventStore.Query<Address>().Select(x => AddressDto.FromAddress(x)).ToList()
                });
        }
    }
}
