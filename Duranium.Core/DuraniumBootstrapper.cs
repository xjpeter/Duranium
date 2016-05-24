using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Autofac;

using Duranium.Common;

namespace Duranium.Core
{
    public static class DuraniumBootstrapper
    {
        public static void Initialise(ContainerBuilder builder, string assemblySearchPattern)
        {
            builder.RegisterType<RouterService>().As<IRouterService>().SingleInstance();
            builder.RegisterType<RequestResponseReflectionService>().As<IRequestResponseReflectionService>().SingleInstance();

            ConfigureDuraniumScan(builder, assemblySearchPattern);
        }

        private static void ConfigureDuraniumScan(ContainerBuilder builder, string assemblySearchPattern)
        {
            var assemblyDatas = GetAssemblyDatas(assemblySearchPattern);

            foreach (var assemblyData in assemblyDatas)
            {
                var bootstrapper = Activator.CreateInstance(assemblyData.Bootstrapper) as IBootstrapper;
                bootstrapper?.Initialise(builder);

                foreach (var requestHandlerTypeData in assemblyData.RequestHandlerTypes)
                {
                    builder.RegisterType(requestHandlerTypeData.MainType).As(requestHandlerTypeData.InterfaceType).InstancePerDependency();
                }
            }
        }

        private static IEnumerable<AssemblyData> GetAssemblyDatas(string assemblySearchPattern)
        {
            var files = Directory.GetFiles(".", assemblySearchPattern);

            foreach (var file in files)
            {
                var reflectedAssembly = Assembly.LoadFrom(file);

                var requestHandlerTypes = AssemblyScannerService.GetRequestHandlerTypes(reflectedAssembly);
                var bootstrapperType = AssemblyScannerService.GetBootstrapperType(reflectedAssembly);

                yield return new AssemblyData(requestHandlerTypes, bootstrapperType);
            }
        }
    }
}