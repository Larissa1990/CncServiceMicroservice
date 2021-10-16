using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CncService.Domain.CncServiceAggregate;

namespace CncService.Domain.Events
{
    public class EndpointAddedDomainEvent:INotification
    {
        public Endpoint endpoint { get; }
        public EndpointAddedDomainEvent(Endpoint endpoint)
        {
            this.endpoint = endpoint;
        }
    }
}
