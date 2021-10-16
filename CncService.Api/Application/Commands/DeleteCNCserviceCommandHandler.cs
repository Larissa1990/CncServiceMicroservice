using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using CncService.Domain.CncServiceAggregate;
using System.Threading;

namespace CncService.Api.Application.Commands
{
    public class DeleteCNCserviceCommandHandler : IRequestHandler<DeleteCNCserviceCommand,bool>
    {
        private readonly ICncServiceRepository repository;
        public DeleteCNCserviceCommandHandler(ICncServiceRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool>Handle(DeleteCNCserviceCommand command, CancellationToken cancellationToken)
        {
            var service = await repository.GetByIdAsync(command.serviceId);
            repository.Delete(service);
            return await repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
