using System;

using Autofac;
using Unionized.Interface.Service;

namespace Unionized.Service
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EncryptionService>().As<IEncryptionService>().InstancePerLifetimeScope();
            builder.RegisterType<NetworkLogService>().As<INetworkLogService>().InstancePerLifetimeScope();
            builder.RegisterType<MonitoredServerService>().As<IMonitoredServerService>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
