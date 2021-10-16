using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CncService.Api.Application.Commands
{
    // update address, binding properties of endpoint, not capability (contract)
    public class UpdateEndpointCommand:IRequest<bool>
    {
        public string serviceId { get; }
        public int endpointId { get; }
        public string address { get; }
        public double openTimeout { get; }
        public double closeTimeout { get; }
        public double sendTimeout { get; }
        public double receiveTimeout { get; }
        public string bindType { get; }

        public UpdateEndpointCommand(string serviceId, int endpointId, string address,double openTimeout,
            double closeTimeout, double sendTimeout, double receiveTimeout, string bindType)
        {
            this.serviceId = serviceId;
            this.endpointId = endpointId;
            this.openTimeout = openTimeout;
            this.closeTimeout = closeTimeout;
            this.sendTimeout = sendTimeout;
            this.receiveTimeout = receiveTimeout;
            this.bindType = bindType;
            this.address = address;
        }
    }
}
