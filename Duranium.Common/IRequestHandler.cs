using System.Threading.Tasks;

namespace Duranium.Common
{
    public interface IRequestHandler
    {
        Task<IResponse> ExecuteAsync(IRequest request);
    }

    public interface IRequestHandler<TRequest, TResponse> : IRequestHandler
        where TRequest : IRequest
        where TResponse : IResponse
    {
    }
}