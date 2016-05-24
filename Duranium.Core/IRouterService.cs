using System.Threading.Tasks;

using Duranium.Common;

namespace Duranium.Core
{
    public interface IRouterService
    {
        Task<IResponse> ExecuteRequest(IRequest request);
    }
}