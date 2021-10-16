using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CncService.Domain.CncServiceAggregate;
using Microsoft.EntityFrameworkCore;

namespace CncService.Infrastructure
{
    public class CncServiceFactory : ICncServiceFactory
    {
        private readonly CncServiceContext _context;
        public CncServiceFactory()
        {
            _context = new CncServiceContext();
        }

        public async Task<CNCService> BuildServiceByIdAsnyc(string id)
        {
            CNCService service = await _context.services
                .Include(s => s.endpoints)
                .ThenInclude(e => e.binding)
                .Include(s => s.endpoints)
                .ThenInclude(e => e.contract).Where(s => s.id == id).SingleOrDefaultAsync();

            return service;
        }

        public async Task<List<CNCService>> BuildServicesAsync()
        {
            List<CNCService> services = await _context.services
                .Include(s => s.endpoints)
                .ThenInclude(e => e.binding)
                .Include(s => s.endpoints)
                .ThenInclude(e => e.contract).ToListAsync();
            return services;
        }

        public async Task<List<CNCService>> BuildBySubAsync(string subid)
        {
            List<Subscribe> subs = await _context.subscribers.Where(x => x.subid == subid).ToListAsync();
            List<CNCService> services = new List<CNCService>();
            foreach(var sub in subs)
            {
                CNCService service = await BuildServiceByIdAsnyc(sub.serviceid);
                services.Add(service);
            }
            return services;
        }

    }
}
