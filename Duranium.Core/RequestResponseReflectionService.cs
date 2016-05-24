using System;
using System.Linq;

using Duranium.Common;

namespace Duranium.Core
{
    internal class RequestResponseReflectionService : IRequestResponseReflectionService
    {
        public Type GetMatchingResponseType(Type requestType)
        {
            return GetResponseType(requestType, typeof(IRequest));
        }

        private static Type GetResponseType(Type requestType, Type interfaceRequestType)
        {
            return GetRequestInterface(requestType, interfaceRequestType).GetGenericArguments()[0];
        }

        private static Type GetRequestInterface(Type requestType, Type requestInterface)
        {
            return requestType.GetInterfaces()
                              .Single(type => type.IsGenericType &&
                                              requestInterface.IsAssignableFrom(type.GetGenericTypeDefinition()));
        }
    }
}