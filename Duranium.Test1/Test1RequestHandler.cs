using System;
using System.Threading.Tasks;

using Duranium.Common;

namespace Duranium.Test1
{
    public class Test1RequestHandler : RequestHandler<Test1Request, Test1Response>
    {
        public Test1RequestHandler(ILog log) 
            : base(log)
        {
        }

        protected override Task<Test1Response> HandleAsync(Test1Request request)
        {
            //await Task.Delay(TimeSpan.FromSeconds(5));

            //return new Test1Response();

            return Task.FromResult(new Test1Response());
        }
    }
}