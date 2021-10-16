using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CncService.Api.Application.Commands
{
    public class AddCNCserviceCommand : IRequest<bool>
    {
        public string name { get; }
        public string version { get; }
        public string providerId { get; }
        public string description { get; }
        public int granularity { get; }
        public AddCNCserviceCommand(string name, string version, string providerId, string description, int granularity)
        {
            this.name = name;
            this.version = version;
            this.providerId = providerId;
            this.description = description;
            this.granularity = granularity;
        }
    }
}
