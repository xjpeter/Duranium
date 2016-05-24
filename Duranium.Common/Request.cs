using System;

namespace Duranium.Common
{
    public class Request<TResponse> : IRequest<TResponse>
        where TResponse : IResponse
    {
        public Guid Id { get; set; }
    }
}