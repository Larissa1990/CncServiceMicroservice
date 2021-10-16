using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using CncService.Domain.CncServiceAggregate;
using System.Threading;

namespace CncService.Api.Application.Commands
{
    public class DeleteCapabilityCommandHandler : IRequestHandler<DeleteCapabilityCommand,bool>
    {
        private readonly ICncServiceRepository repository;
        public DeleteCapabilityCommandHandler(ICncServiceRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool>Handle(DeleteCapabilityCommand command, CancellationToken cancellationToken)
        {
            var service = await repository.GetByIdAsync(command.serviceId);
            service.RemoveCapability(command.endpointId, command.capabilityId);
            repository.Update(service);
            return await repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
         
    }
}
