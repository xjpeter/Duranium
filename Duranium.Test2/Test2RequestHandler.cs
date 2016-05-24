using System;
using System.Threading.Tasks;

using Duranium.Common;

namespace Duranium.Test2
{
    public class Test2RequestHandler : RequestHandler<Test2Request, Test2Response>
    {
        public Test2RequestHandler(ILog log) 
            : base(log)
        {
        }

        protected override Task<Test2Response> HandleAsync(Test2Request request)
        {
            //await Task.Delay(TimeSpan.FromSeconds(5));

            //return new Test2Response();
            //await Task.Delay(TimeSpan.FromSeconds(5));

            //return new Test1Response();

            return Task.FromResult(new Test2Response());
        }
    }
}