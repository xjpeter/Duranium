using Duranium.Common;

namespace Duranium.Test1
{
    public class Test1RequestHandler : RequestHandler<Test1Request, Test1Response>
    {
        public Test1RequestHandler(ILog log) 
            : base(log)
        {
        }

        protected override Test1Response Handle(Test1Request request)
        {
            //await Task.Delay(TimeSpan.FromSeconds(5));

            //return new Test1Response();

            return new Test1Response();
        }
    }
}