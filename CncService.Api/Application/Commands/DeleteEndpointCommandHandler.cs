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
    public class DeleteEndpointCommandHandler:IRequestHandler<DeleteEndpointCommand,bool>
    {
        private readonly ICncServiceRepository repository;
        public DeleteEndpointCommandHandler(ICncServiceRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool>Handle(DeleteEndpointCommand command, CancellationToken cancellationToken)
        {
            var service = await repository.GetByIdAsync(command.serviceId);
            service.RemoveEndpoint(command.endpointId);
            repository.Update(service);
            return await repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
