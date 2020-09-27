using System;

using Autofac;
using AutoMapper;

using Unionized.Contract;
using Unionized.Contract.Repository;
using Unionized.Model.Database.Repository;

namespace Unionized.Model.Database
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(r =>
            {
                var config = new MapperConfiguration(cfg =>
                  {
                      cfg.CreateMap<NetworkLog, NetworkLogModel>().ReverseMap();
                      cfg.CreateMap<UserToken, UserTokenModel>().ReverseMap();
                      cfg.CreateMap<MonitoredServer, MonitoredServersModel>().ReverseMap();
                  });

                var map = config.CreateMapper();

                return map;
            }).As<IMapper>().SingleInstance();

            builder.RegisterType<NetworkLogRepository>().As<INetworkLogRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TokenRepository>().As<ITokenRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MonitoredServersRepository>().As<IMonitorServersRepository>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
