using System;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

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

            Observable.Interval(TimeSpan.FromSeconds(2))
                      .Select(interval =>
                              {
                                  if(interval % 2 == 0)
                                  {
                                      return new Test2Request { Id = Guid.NewGuid() } as IRequest;
                                  }

                                  return new Test1Request {Id = Guid.NewGuid()} as IRequest;
                              }).SelectMany(request => routerService.ExecuteRequest(request).ToObservable())
                    .Subscribe();

            Console.ReadKey();
        }
    }
}