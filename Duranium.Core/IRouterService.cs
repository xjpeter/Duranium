using Duranium.Common;

namespace Duranium.Core
{
    public interface IRouterService
    {
        IResponse ExecuteRequest(IRequest request);
    }
}