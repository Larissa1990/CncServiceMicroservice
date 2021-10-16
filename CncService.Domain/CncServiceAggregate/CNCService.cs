using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using MediatR;
using CncService.Domain.Events;

namespace CncService.Domain.CncServiceAggregate
{
    [Table("cncservice")]
    public class CNCService
    {
        private List<INotification> _domainEvents;

        [Column("serviceid")]
        public string id { get;  set; }
        public string name { get; set; }
        public string version { get;  set; }
        public string providerId { get; set; }
        public string description { get;  set; }
        public int granularity { get;  set; }

        [NotMapped]
        public List<Endpoint> endpoints { get; set; }

        [NotMapped]
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        // build new cncservice
        public CNCService(string name, string version, string providerId, string description, int granularity)
        {
            this.name = name;
            this.version = version;
            this.providerId = providerId;
            this.description = description;
            this.granularity = granularity;
            id = Guid.NewGuid().ToString();
        }

        public CNCService()
        {

        }

        public void AddEndpoint(Endpoint endpoint)
        {
            endpoints = endpoints ?? new List<Endpoint>();
            endpoints.Add(endpoint);
            endpoint.serviceid = this.id;
            //AddDomainEvent(new EndpointAddedDomainEvent(endpoint));
        }

        public void RemoveEndpoint(int endpointId)
        {
            var endpoint = endpoints.Where(x => x.id==endpointId).Single();
            endpoints.Remove(endpoint);
            //AddDomainEvent(new EndpointDeletedDomainEvent(endpoint));
        }

        public void UpdateEndpoint(int endpointId,string address,double openTimeout, double closeTimeout,
            double sendTimeout, double receiveTimeout, string bindType)
        {
            Endpoint oldPoint = endpoints.Where(x => x.id == endpointId).Single();
            oldPoint.Update(address, openTimeout, closeTimeout,sendTimeout, receiveTimeout, bindType);
            //AddDomainEvent(new EndpointUpdatedDomainEvent(endpoint));
        }

        public void AddCapability(int endpointId,string name,string input, string output)
        {
            Endpoint oldPoint = endpoints.Where(x => x.id == endpointId).Single();
            oldPoint.AddCapability(name, input, output);
        }

        public void UpdateCapability(int endpointId, string capabilityId, string name, string input,string output)
        {
            Endpoint oldPoint = endpoints.Where(x => x.id == endpointId).Single();
            oldPoint.UpdateCapability(capabilityId,name,input,output);
        }

        public void RemoveCapability(int endpointId, string capabilityId)
        {
            Endpoint oldPoint = endpoints.Where(x => x.id == endpointId).Single();
            oldPoint.RemoveCapability(capabilityId);
        }

        private void AddDomainEvent(INotification domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

    }
}
