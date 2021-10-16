using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using CncService.Domain.CncServiceAggregate;
using System.Threading;
using static CncService.Api.Application.DTO;

namespace CncService.Api.Application.Commands
{
    public class UpdateEndpointCommandHandler:IRequestHandler<UpdateEndpointCommand,bool>
    {
        private readonly ICncServiceRepository repository;
        public UpdateEndpointCommandHandler(ICncServiceRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool>Handle(UpdateEndpointCommand command, CancellationToken cancellationToken)
        {
            var service = await repository.GetByIdAsync(command.serviceId);
            service.UpdateEndpoint(command.endpointId, command.address, command.openTimeout,
                command.closeTimeout, command.sendTimeout, command.receiveTimeout, command.bindType);
            repository.Update(service);
            return await repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
