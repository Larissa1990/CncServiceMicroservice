using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using CncService.Domain.CncServiceAggregate;

namespace CncService.Api.Application.Commands
{
    public class SubscribeToCapabilityCommandHandler : IRequestHandler<SubscribeToCapabilityCommand,bool>
    {
        private readonly ICncServiceRepository repository;
        public SubscribeToCapabilityCommandHandler(ICncServiceRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(SubscribeToCapabilityCommand command, CancellationToken cancellationToken)
        {
            repository.Subscribe(command.serviceid,command.subid);
            return await repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
