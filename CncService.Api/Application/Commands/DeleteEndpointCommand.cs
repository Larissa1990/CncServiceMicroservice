using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CncService.Api.Application.Commands
{
    public class DeleteEndpointCommand:IRequest<bool>
    {
        public string serviceId { get; }
        public int endpointId { get; }
        public DeleteEndpointCommand(string serviceId, int endpointId)
        {
            this.serviceId = serviceId;
            this.endpointId = endpointId;
        }
    }
}
