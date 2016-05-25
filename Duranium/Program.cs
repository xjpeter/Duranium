using System;

using Autofac;

using Duranium.Common;
using Duranium.Core;
using Duranium.Test1;
using Duranium.Test2;

namespace Duranium
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ConsoleLog>().As<ILog>().SingleInstance();

            DuraniumBootstrapper.Initialise(builder, "Duranium.Test*.dll");

            var container = builder.Build();

            IoC.Container = container;

            var routerService = container.Resolve<IRouterService>();

            var count = 0;

            while (true)
            {
                IRequest request;
                if (count%2 == 0)
                {
                    request = new Test2Request {Id = Guid.NewGuid()};
                }
                else
                {
                    request = new Test1Request {Id = Guid.NewGuid()};
                }

                routerService.ExecuteRequest(request);

                count++;
            }

            Console.ReadKey();
        }
    }
}