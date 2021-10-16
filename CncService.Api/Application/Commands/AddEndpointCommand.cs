using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CncService.Api.Application.Commands
{
    public class AddEndpointCommand : IRequest<bool>
    {
        public Endpoint endpoint { get; }
        public string serviceId { get; }
        public AddEndpointCommand(Endpoint endpoint, string serviceId)
        {
            this.endpoint = endpoint;
            this.serviceId = serviceId;
        }
    }
}
