using System;

namespace Duranium.Core
{
    public interface IReflectionService
    {
        Type GetRequestHandlerType(Type requestType);
    }
}