using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using System.Threading;
using CncService.Domain.CncServiceAggregate;
using CncService.Infrastructure;
using static CncService.Api.Application.DTO;

namespace CncService.Api.Application.Commands
{
    public class AddEndpointCommandHandler : IRequestHandler<AddEndpointCommand,bool>
    {
        private readonly ICncServiceRepository repository;
        public AddEndpointCommandHandler(ICncServiceRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool>Handle(AddEndpointCommand command, CancellationToken cancellationToken)
        {
            var service = await repository.GetByIdAsync(command.serviceId);

            List<Domain.CncServiceAggregate.Capability> contract = new List<Domain.CncServiceAggregate.Capability>();
            foreach(var capability in command.endpoint.contract)
            {
                Domain.CncServiceAggregate.Capability _capability = new Domain.CncServiceAggregate.Capability(capability.name,
                    capability.input, capability.output);
                contract.Add(_capability);
            }

            Domain.CncServiceAggregate.Endpoint endpoint = new Domain.CncServiceAggregate.Endpoint(command.endpoint.address,
                command.endpoint.openTimeout,command.endpoint.closeTimeout,command.endpoint.sendTimeout,command.endpoint.receiveTimeout,
                command.endpoint.bindType,contract);

            service.AddEndpoint(endpoint);
            repository.Update(service);
            return await repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
