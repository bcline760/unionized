using System;
using Autofac;

using Unionized.DI;
using Unionized.Service.Implementation;
using Unionized.Service.Interface;

namespace Unionized.Service
{
    public class ServicesModule : IRegister
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<NetworkLogService>().As<INetworkLogService>().InstancePerDependency();
            builder.RegisterType<SessionService>().As<ISessionService>().InstancePerDependency();
        }
    }
}
