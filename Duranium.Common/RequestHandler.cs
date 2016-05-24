using System;
using System.Threading.Tasks;

namespace Duranium.Common
{
    public abstract class RequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IResponse
    {
        private readonly ILog _log;

        protected RequestHandler(ILog log)
        {
            _log = log;
        }

        public async Task<IResponse> ExecuteAsync(IRequest request)
        {
            var typedRequest = (TRequest)request;

            _log.Debug($"Executing BeforeExecuteAsync on request : {request.GetType().Name}, Id - {request.Id} @ {DateTime.Now}");

            typedRequest = await BeforeExecuteAsync(typedRequest);

            _log.Debug($"Executing HandleAsync on request : {request.GetType().Name}, Id - {request.Id} @ {DateTime.Now}");

            var response = await HandleAsync(typedRequest);

            _log.Debug($"Executing AfterExecuteAsync on request : {request.GetType().Name}, Id - {request.Id} @ {DateTime.Now}");

            response = await AfterExecuteAsync(request, response);

            return response;
        }

        protected abstract Task<TResponse> HandleAsync(TRequest request);

        protected virtual Task<TRequest> BeforeExecuteAsync(TRequest request)
        {
            return Task.FromResult(request);
        }

        protected virtual Task<TResponse> AfterExecuteAsync(IRequest request, TResponse response)
        {
            return Task.FromResult(response);
        }
    }
}