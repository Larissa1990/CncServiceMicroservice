using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using CncService.Domain.CncServiceAggregate;
using System.Threading;

namespace CncService.Api.Application.Commands
{
    public class UpdateCapabilityCommandHandler : IRequestHandler<UpdateCapabilityCommand,bool>
    {
        private readonly ICncServiceRepository repository;
        public UpdateCapabilityCommandHandler(ICncServiceRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool>Handle(UpdateCapabilityCommand command,CancellationToken cancellationToken)
        {
            var service = await repository.GetByIdAsync(command.serviceId);
            service.UpdateCapability(command.endpointId, command.capability.id, command.capability.name, command.capability.input,
                command.capability.output);
            repository.Update(service);
            return await repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            
        }
    }
}
