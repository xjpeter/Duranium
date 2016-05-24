using System;

namespace Duranium.Core
{
    public interface IRequestResponseReflectionService
    {
        Type GetMatchingResponseType(Type requestType);
    }
}