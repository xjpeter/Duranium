using System;

namespace Duranium.Core
{
    internal class RequestHandlerTypeData
    {
        public RequestHandlerTypeData(Type mainType, Type interfaceType)
        {
            InterfaceType = interfaceType;
            MainType = mainType;
        }

        public Type MainType { get; }

        public Type InterfaceType { get; }
    }
}