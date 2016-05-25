namespace Duranium.Common
{
    public interface IRequestHandler
    {
        IResponse Execute(IRequest request);
    }

    public interface IRequestHandler<TRequest, TResponse> : IRequestHandler
        where TRequest : IRequest
        where TResponse : IResponse
    {
    }
}