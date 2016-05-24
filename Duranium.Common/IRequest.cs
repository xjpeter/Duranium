using System;

namespace Duranium.Common
{
    public interface IRequest
    {
        Guid Id { get; set; }
    }

    public interface IRequest<TResponse> : IRequest
        where TResponse : IResponse
    {
    }
}