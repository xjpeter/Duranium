using System;
using System.Threading.Tasks;

using Autofac;

using Duranium.Common;

namespace Duranium.Core
{
    internal class RouterService : IRouterService
    {
        private readonly ILog _log;
        private readonly IRequestResponseReflectionService _requestResponseReflectionService;

        public RouterService(ILog log, IRequestResponseReflectionService requestResponseReflectionService)
        {
            _log = log;
            _requestResponseReflectionService = requestResponseReflectionService;
        }

        public async Task<IResponse> ExecuteRequest(IRequest request)
        {
            _log.Debug($"Started executing request : {request.GetType().Name}, Id - {request.Id} @ {DateTime.Now}");

            var requestType = request.GetType();

            var responseType = _requestResponseReflectionService.GetMatchingResponseType(requestType);

            var requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, responseType);

            var requestHandler = (IRequestHandler)IoC.Container.Resolve(requestHandlerType);

            var response = await requestHandler.ExecuteAsync(request);

            _log.Debug($"Finished executing request : {request.GetType().Name}, Id - {request.Id} @ {DateTime.Now}");

            return response;
        }
    }
}