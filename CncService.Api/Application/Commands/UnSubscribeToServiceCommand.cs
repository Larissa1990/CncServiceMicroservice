using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CncService.Api.Application.Commands
{
    public class UnSubscribeToServiceCommand : IRequest<bool>
    {
        public string serviceid { get; }
        public string subid { get; }

        public UnSubscribeToServiceCommand(string serviceid, string subid)
        {
            this.serviceid = serviceid;
            this.subid = subid;
        }
    }
}
