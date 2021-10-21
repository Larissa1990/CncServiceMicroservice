using System;
using CncService.Infrastructure;
using CncService.Api.Application.Queries;
using System.Threading;
using CncService.Api.Application.Commands;
using Autofac;
using CncService.Api.AutofacModules;
using MediatR;
using System.Linq;
using CncService.Api.Application;
using System.Collections.Generic;

namespace UnitTest
{
    class Program
    {
        static IContainer container;

        static void BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new MediatorModules());
            builder.RegisterModule(new ApplicationModules());
            container = builder.Build();
        }
        static void Main(string[] args)
        {
            IMediator mediator;
            ICNCserviceQuery query;
            BuildContainer();
            using(var scope = container.BeginLifetimeScope())
            {
                mediator = scope.Resolve<IMediator>();
                query = scope.Resolve<ICNCserviceQuery>();
                var service = query.GetAllAsync().Result[0];
                Capability capability = new Capability()
                {
                    name = "point2-1",
                    input = "string",
                    output = "double"
                };
                Endpoint endpoint = new Endpoint()
                {
                    address = "http://localhost:13132",
                    openTimeout = 0,
                    closeTimeout = 0,
                    sendTimeout = 0,
                    receiveTimeout = 0,
                    bindType = "RESTful-POST",
                    contract = new List<Capability>() { capability }
                };
                AddEndpointCommand command = new AddEndpointCommand(endpoint, service.id);
                var answer = mediator.Send(command).Result;
                Console.WriteLine(answer);
            }

            Console.Read();
        }
    }
}
