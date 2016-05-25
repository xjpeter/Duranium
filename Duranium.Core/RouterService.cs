using System;

using Autofac;

using Duranium.Common;

namespace Duranium.Core
{
    internal class RouterService : IRouterService
    {
        private readonly ILog _log;
        private readonly IReflectionService _reflectionService;

        public RouterService(ILog log, IReflectionService reflectionService)
        {
            _log = log;
            _reflectionService = reflectionService;
        }

        public IResponse ExecuteRequest(IRequest request)
        {
            _log.Debug($"Started executing request : {request.GetType().Name}, Id - {request.Id} @ {DateTime.Now}");

            var requestType = request.GetType();

            var requestHandlerType = _reflectionService.GetRequestHandlerType(requestType);

            var requestHandler = (IRequestHandler)IoC.Container.Resolve(requestHandlerType);

            var response = requestHandler.Execute(request);

            _log.Debug($"Finished executing request : {request.GetType().Name}, Id - {request.Id} @ {DateTime.Now}");

            return response;
        }
    }
}