using System.Diagnostics;

using Autofac;

using Duranium.Common;

namespace Duranium.Test1
{
    public class Test1Bootstrapper : IBootstrapper
    {
        public void Initialise(ContainerBuilder builder)
        {
            Debug.WriteLine("Test1 Bootstrapper");
        }
    }
}