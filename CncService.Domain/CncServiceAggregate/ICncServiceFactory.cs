using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CncService.Domain.CncServiceAggregate
{
    public interface ICncServiceFactory
    {
        Task<CNCService> BuildServiceByIdAsnyc(string id);
        Task<List<CNCService>> BuildServicesAsync();
        Task<List<CNCService>> BuildServicesByGranularityAsync(int granularity);
        Task<List<CNCService>> BuildBySubAsync(string subid);
    }
}
