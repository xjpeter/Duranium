using System;

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

        public IResponse Execute(IRequest request)
        {
            var typedRequest = (TRequest)request;

            _log.Debug($"Executing BeforeExecute on request : {request.GetType().Name}, Id - {request.Id} @ {DateTime.Now}");

            typedRequest = BeforeExecute(typedRequest);

            _log.Debug($"Executing Handle on request : {request.GetType().Name}, Id - {request.Id} @ {DateTime.Now}");

            var response = Handle(typedRequest);

            _log.Debug($"Executing AfterExecute on request : {request.GetType().Name}, Id - {request.Id} @ {DateTime.Now}");

            response = AfterExecute(request, response);

            return response;
        }

        protected abstract TResponse Handle(TRequest request);

        protected virtual TRequest BeforeExecute(TRequest request)
        {
            return request;
        }

        protected virtual TResponse AfterExecute(IRequest request, TResponse response)
        {
            return response;
        }
    }
}