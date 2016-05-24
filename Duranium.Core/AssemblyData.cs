using System;
using System.Collections.Generic;

namespace Duranium.Core
{
    internal class AssemblyData
    {
        public AssemblyData(IEnumerable<RequestHandlerTypeData> requestHandlerTypes, Type bootstrapper)
        {
            RequestHandlerTypes = requestHandlerTypes;
            Bootstrapper = bootstrapper;
        }

        public IEnumerable<RequestHandlerTypeData> RequestHandlerTypes { get; }

        public Type Bootstrapper { get; }
    }
}