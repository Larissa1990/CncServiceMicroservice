using System;
using Xunit;
using CncService.Domain.CncServiceAggregate;
using CncService.Infrastructure;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public bool GetCncServices()
        {
            ICncServiceFactory factory = new CncServiceFactory();
            var services = factory.BuildServicesAsync().Result;
            if (services.Count > 0)
                return true;
            return false;
        }
    }
}
