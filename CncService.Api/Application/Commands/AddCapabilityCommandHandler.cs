using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using System.Threading;
using CncService.Domain.CncServiceAggregate;

namespace CncService.Api.Application.Commands
{
    public class AddCapabilityCommandHandler : IRequestHandler<AddCapabilityCommand,bool>
    {
        private readonly ICncServiceRepository repository;
        public AddCapabilityCommandHandler(ICncServiceRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool>Handle(AddCapabilityCommand command, CancellationToken cancellationToken)
        {
            var service = await repository.GetByIdAsync(command.serviceId);
            service.AddCapability(command.endpointId, command.capability.name, command.capability.input, command.capability.output);
            repository.Update(service);
            return await repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
