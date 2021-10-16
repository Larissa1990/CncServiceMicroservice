using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CncService.Api.Application.Commands
{
    public class DeleteCapabilityCommand : IRequest<bool>
    {
        public string serviceId { get; }
        public int endpointId { get; }

        public string capabilityId { get; }

        public DeleteCapabilityCommand(string serviceId, int endpointId, string capabilityId)
        {
            this.serviceId = serviceId;
            this.endpointId = endpointId;
            this.capabilityId = capabilityId;
        }
    }
}
