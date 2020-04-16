using System;

using Autofac;
using Unionized.Contract.Service;

namespace Unionized.Service
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Ldap>().As<ILdap>().InstancePerLifetimeScope();
            builder.RegisterType<SessionService>().As<ISessionService>().InstancePerLifetimeScope();
            builder.RegisterType<TokenService>().As<ITokenService>().InstancePerLifetimeScope();
            builder.RegisterType<EncryptionService>().As<IEncryptionService>().InstancePerLifetimeScope();
            builder.RegisterType<NetworkLogService>().As<INetworkLogService>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
