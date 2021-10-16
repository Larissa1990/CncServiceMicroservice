using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using CncService.Domain.CncServiceAggregate;
using System.Threading;

namespace CncService.Api.Application.Commands
{
    public class AddCNCserviceCommandHandler : IRequestHandler<AddCNCserviceCommand,bool>
    {
        private readonly ICncServiceRepository repository;
        public AddCNCserviceCommandHandler(ICncServiceRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool>Handle(AddCNCserviceCommand command, CancellationToken cancellationToken)
        {
            CNCService service = new CNCService(command.name, command.version, 
                command.providerId, command.description, command.granularity);
            repository.Add(service);
            return await repository.UnitOfWork.SaveEntitiesAsync();
        }

        
    }
}
