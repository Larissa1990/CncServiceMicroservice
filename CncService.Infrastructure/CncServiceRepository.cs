using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CncService.Domain.CncServiceAggregate;
using CncService.Domain;

namespace CncService.Infrastructure
{
    public class CncServiceRepository : ICncServiceRepository
    {
        private readonly CncServiceContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public CncServiceRepository(CncServiceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public CncServiceRepository()
        {
            _context = new CncServiceContext();
        }

        public void Add(CNCService service)
        {
            _context.services.Add(service);
        }

        public void Update(CNCService service)
        {
            _context.Entry(service).State = EntityState.Modified;
        }

        public void Delete(CNCService service)
        {
            _context.Entry(service).State = EntityState.Deleted;
        }

        public void Subscribe(string serviceid, string subid)
        {
            _context.subscribers.Add(new Domain.CncServiceAggregate.Subscribe(serviceid, subid));
        }

        public void UnSubscribe(string serviceid, string subid)
        {
            Subscribe sub = _context.subscribers.Where(x => x.serviceid == serviceid && x.subid == subid).Single();
            _context.Entry(sub).State = EntityState.Deleted;
        }

        public async Task<CNCService>GetByIdAsync(string id)
        {
            CNCService service = await _context.services
                .Include(s => s.endpoints)
                .ThenInclude(e => e.binding)
                .Include(s => s.endpoints)
                .ThenInclude(e => e.contract).Where(s => s.id == id).SingleOrDefaultAsync();

            return service;
        }
    }
}
