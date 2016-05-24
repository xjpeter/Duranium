using Autofac;

namespace Duranium.Common
{
    public interface IBootstrapper
    {
        void Initialise(ContainerBuilder builder);
    }
}