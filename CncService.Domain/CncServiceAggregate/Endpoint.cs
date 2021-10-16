using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CncService.Domain.CncServiceAggregate
{
    [Table("endpoint")]
    public class Endpoint
    {
        public int id { get; set; }
        public string address { get; set; }
        public string serviceid { get; set; }

        [NotMapped]
        public Binding binding { get; set; }
        [NotMapped]
        public List<Capability> contract { get; set; }

        public Endpoint()
        {

        }

        public Endpoint(string address, double opentimeout, double closetimeout, double sendtimeout,double receivetimeout,string bindtype, List<Capability> contract)
        {
            this.address = address;
            this.binding = new Binding(opentimeout, closetimeout, sendtimeout, receivetimeout, bindtype);
            this.contract = contract;
        }

        public void Update(string address, double opentimeout, double closetimeout,double sendtimeout,double receivetimeout,string bindtype)
        {
            this.address = address;
            this.binding = new Binding(opentimeout, closetimeout, sendtimeout, receivetimeout, bindtype);
        }

        public void AddCapability(string name, string input, string output)
        {
            Capability capability = new Capability(name, input, output);
            contract.Add(capability);
        }

        public void UpdateCapability(string capabilityId, string name,string input, string output)
        {
            Capability old = contract.Where(x => x.id == capabilityId).Single();
            old.Update(name, input, output);
        }

        public void RemoveCapability(string id)
        {
            Capability old = contract.Where(x => x.id == id).Single();
            contract.Remove(old);
        }

    }
}
