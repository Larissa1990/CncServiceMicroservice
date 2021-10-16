using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using System.Reflection;
using CncService.Api.Application.Queries;
using CncService.Infrastructure;
using CncService.Domain.CncServiceAggregate;

namespace CncService.Api.AutofacModules
{
    public class ApplicationModules: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CNCserviceQuery>()
                .As<ICNCserviceQuery>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CncServiceRepository>()
                .As<ICncServiceRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CncServiceFactory>()
                .As<ICncServiceFactory>()
                .InstancePerLifetimeScope();
        }
    }
}
