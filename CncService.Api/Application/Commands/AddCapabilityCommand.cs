using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CncService.Api.Application.Commands
{
    public class AddCapabilityCommand : IRequest<bool>
    {
        public string serviceId { get; }
        public int endpointId { get; }

        public Capability capability { get; }

        public AddCapabilityCommand(string serviceId, int endpointId, Capability capability)
        {
            this.serviceId = serviceId;
            this.endpointId = endpointId;
            this.capability = capability;
        }
    }
}
