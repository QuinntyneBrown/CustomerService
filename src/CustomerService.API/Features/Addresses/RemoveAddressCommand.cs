using CustomerService.Core.Interfaces;
using CustomerService.Core.Models;
using FluentValidation;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace CustomerService.API.Features.Addresses
{
    public class RemoveAddressCommand
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.AddressId).NotEqual(default(Guid));
            }
        }

        public class Request : IRequest
        {
            public Guid AddressId { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IEventStore _eventStore;
            
            public Handler(IEventStore eventStore) => _eventStore = eventStore;

            public Task Handle(Request request, CancellationToken cancellationToken)
            {
                var address = _eventStore.Query<Address>(request.AddressId);

                address.Remove();
                
                _eventStore.Save(address);

                return Task.CompletedTask;
            }
        }
    }
}
