using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CncService.Api.Application.Commands
{
    public class DeleteCNCserviceCommand : IRequest<bool>
    {
        public string serviceId { get; }
        public DeleteCNCserviceCommand(string serviceId)
        {
            this.serviceId = serviceId;
        }
    }
}
