using System;
using System.Collections.Generic;
using System.Linq;

using Duranium.Common;

namespace Duranium.Core
{
    internal class ReflectionService : IReflectionService
    {
        private readonly IDictionary<Type, Type> _requestResponseMapping = new Dictionary<Type, Type>();
        private readonly IDictionary<Type, Type> _requestToRequestHandlerMapping = new Dictionary<Type, Type>();

        public Type GetRequestHandlerType(Type requestType)
        {
            Type requestHandlerType;

            if (!_requestToRequestHandlerMapping.TryGetValue(requestType, out requestHandlerType))
            {
                var responseType = GetMatchingResponseType(requestType);

                requestHandlerType = GetRequestHandlerType(requestType, responseType);

                _requestToRequestHandlerMapping.Add(requestType, requestHandlerType);
            }

            return requestHandlerType;
        }

        private Type GetMatchingResponseType(Type requestType)
        {
            Type responseType;

            if (!_requestResponseMapping.TryGetValue(requestType, out responseType))
            {
                responseType = GetResponseType(requestType, typeof(IRequest));

                _requestResponseMapping.Add(requestType, responseType);
            }

            return responseType;
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

        private static Type GetRequestHandlerType(Type requestType, Type responseType)
        {
            return typeof(IRequestHandler<,>).MakeGenericType(requestType, responseType);
        }
    }
}