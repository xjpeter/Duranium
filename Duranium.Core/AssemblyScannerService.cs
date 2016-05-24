using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Duranium.Common;

namespace Duranium.Core
{
    internal class AssemblyScannerService
    {
        public static Type GetBootstrapperType(Assembly assembly)
        {
            return assembly.GetTypes()
                           .FirstOrDefault(type => type.IsClass &&
                                                   type.GetInterfaces().Contains(typeof(IBootstrapper)));
        }

        public static IEnumerable<RequestHandlerTypeData> GetRequestHandlerTypes(Assembly assembly)
        {
            return assembly.GetTypes()
                           .Where(type => type.IsClass)
                           .Select(type =>
                                   {
                                       var interfaceType = type.GetInterfaces()
                                                               .FirstOrDefault(i => i.IsGenericType &&
                                                                                    i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

                                       return new RequestHandlerTypeData(type, interfaceType);
                                   })
                           .Where(type => type.InterfaceType != null);
        }
    }
}