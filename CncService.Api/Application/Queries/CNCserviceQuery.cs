using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using CncService.Domain.CncServiceAggregate;
using CncService.Infrastructure;

namespace CncService.Api.Application.Queries
{
    public class CNCserviceQuery:ICNCserviceQuery
    {
        private readonly ICncServiceFactory factory;

        public CNCserviceQuery(ICncServiceFactory factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public async Task<List<CNCservice>> GetAllAsync()
        {
            var services = await factory.BuildServicesAsync();
            return DTO.ToExternals(services);
        }

        public async Task<CNCservice> GetByIdAsync(string id)
        {
            var service = await factory.BuildServiceByIdAsnyc(id);
            return DTO.ToExternal(service);
        }
        public async Task<List<CNCservice>> GetByProviderAsync(string providerId)
        {
            throw new NotImplementedException();
        }
        public async Task<List<CNCservice>> GetByGranularityAsync(int granularity)
        {
            throw new NotImplementedException();
        }
        public async Task<List<CNCservice>> GetBySubscriberAsync(string subid)
        {
            return DTO.ToExternals(await factory.BuildBySubAsync(subid));
        }
    }
}
