using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CncService.Domain.CncServiceAggregate;

namespace CncService.Domain.Events
{
    public class EndpointDeletedDomainEvent:INotification
    {
        public Endpoint endpoint { get; }
        public EndpointDeletedDomainEvent(Endpoint endpoint)
        {
            this.endpoint = endpoint;
        }
    }
}
