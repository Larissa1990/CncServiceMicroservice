using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CncService.Api.Application.DTO;

namespace CncService.Api.Application.Queries
{
    public interface ICNCserviceQuery
    {
        Task<List<CNCservice>> GetAllAsync();
        Task<CNCservice> GetByIdAsync(string id);
        Task<List<CNCservice>> GetByProviderAsync(string providerId);
        Task<List<CNCservice>> GetByGranularityAsync(int granularity);
        Task<List<CNCservice>> GetBySubscriberAsync(string subId);
    }
}
