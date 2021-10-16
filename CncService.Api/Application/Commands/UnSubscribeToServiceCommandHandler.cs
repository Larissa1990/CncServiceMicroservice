using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using CncService.Domain.CncServiceAggregate;

namespace CncService.Api.Application.Commands
{
    public class UnSubscribeToServiceCommandHandler : IRequestHandler<UnSubscribeToServiceCommand,bool>
    {
        private readonly ICncServiceRepository repository;

        public UnSubscribeToServiceCommandHandler(ICncServiceRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool>Handle(UnSubscribeToServiceCommand command, CancellationToken cancellationToken)
        {
            repository.UnSubscribe(command.serviceid, command.subid);
            return await repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
