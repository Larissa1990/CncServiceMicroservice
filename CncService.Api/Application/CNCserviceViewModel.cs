using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CncService.Domain.CncServiceAggregate;

namespace CncService.Api.Application
{
    public class CNCservice
    {
        public string id { get; set; }
        public string name { get; set; }
        public string version { get; set; }
        public string providerId { get; set; }
        public string description { get; set; }
        public int granularity { get; set; }

        public List<Endpoint> endpoints { get; set; }

        public CNCservice()
        {
            endpoints = new List<Endpoint>();
        }
    }

    public class Endpoint
    {
        public int id { get; set; }
        public string address { get; set; }
        public List<Capability> contract { get; set; }
        public double openTimeout { get; set; }
        public double closeTimeout { get; set; }
        public double sendTimeout { get; set; }
        public double receiveTimeout { get; set; }
        public string bindType { get; set; }

        public Endpoint()
        {
            contract = new List<Capability>();
        }
    }

    public class Capability
    {
        public string id { get; set; }
        public string name { get; set; }
        public string input { get; set; }
        public string output { get; set; }
    }

    public static class DTO
    {
        public static CNCservice ToExternal(CNCService service)
        {
            if (service==null)
                return null;
            CNCservice _service = new CNCservice()
            {
                id=service.id,
                name = service.name,
                version = service.version,
                providerId = service.providerId,
                description = service.description,
                granularity = service.granularity
            };
            _service.endpoints = ToExternals(service.endpoints);
            return _service;
        }

        public static List<CNCservice> ToExternals(List<CNCService> services)
        {
            List<CNCservice> _services = new List<CNCservice>();
            foreach (var service in services)
                _services.Add(ToExternal(service));
            return _services;
        }

        public static Application.Endpoint ToExternal(CncService.Domain.CncServiceAggregate.Endpoint endpoint)
        {
            Application.Endpoint _endpoint = new Endpoint()
            {
                id=endpoint.id,
                address = endpoint.address,
                openTimeout = endpoint.binding.openTimeout,
                closeTimeout = endpoint.binding.closeTimeout,
                receiveTimeout = endpoint.binding.receiveTimeout,
                sendTimeout = endpoint.binding.sendTimeout,
                bindType = endpoint.binding.bindType,
            };

            _endpoint.contract = ToExternals(endpoint.contract);

            return _endpoint;
        }

        public static List<Endpoint> ToExternals(List<Domain.CncServiceAggregate.Endpoint> endpoints)
        {
            List<Endpoint> _endpoints = new List<Endpoint>();
            foreach (var endpoint in endpoints)
                _endpoints.Add(ToExternal(endpoint));
            return _endpoints;
        }

        public static Application.Capability ToExternal(Domain.CncServiceAggregate.Capability capability)
        {
            Capability _capability = new Capability()
            {
                id=capability.id,
                name = capability.name,
                input = capability.input,
                output = capability.output
            };
            return _capability;
        }

        public static List<Capability> ToExternals(List<Domain.CncServiceAggregate.Capability> contract)
        {
            List<Capability> _contract = new List<Capability>();
            foreach(var capability in contract)
            {
                _contract.Add(ToExternal(capability));
            }
            return _contract;
        }

    }
}
