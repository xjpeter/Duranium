using System.Diagnostics;

using Autofac;

using Duranium.Common;

namespace Duranium.Test2
{
    public class Test2Bootstrapper : IBootstrapper
    {
        public void Initialise(ContainerBuilder builder)
        {
            Debug.WriteLine("Test2 Bootstrapper");
        }
    }
}