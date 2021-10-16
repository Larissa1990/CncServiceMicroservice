using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CncService.Domain.CncServiceAggregate
{
    public interface ICncServiceRepository
    {
        void Add(CNCService service);
        void Update(CNCService service);
        void Delete(CNCService service);

        void Subscribe(string serviceid, string subid);
        void UnSubscribe(string serviceid, string subid);
        Task<CNCService> GetByIdAsync(string id);
        IUnitOfWork UnitOfWork { get; }
    }
}
