using MediatR;
using System;

namespace CustomerService.Core.DomainEvents
{
    public class DomainEvent: INotification {
        public Guid CorrelationId { get; set; }
        public Guid CausationId { get; set; }
        public Guid ActivityId { get; set; }
    }
}
