using System;

using Autofac;
using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Unionized.Contract;
using Unionized.Contract.Repository;
using Unionized.Model.Database.Context;
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
                      cfg.CreateMap<AppRole, AppRoleModel>()
                        .ForMember(m => m.Role, o => o.MapFrom(n => n.Role.ToString()))
                        .ReverseMap()
                        .ForMember(m => m.Role, o => o.MapFrom(n => Enum.Parse<RoleType>(n.Role)));
                      cfg.CreateMap<MonitoredServer, MonitoredServersModel>().ReverseMap();
                  });

                var map = config.CreateMapper();

                return map;
            }).As<IMapper>().SingleInstance();

            builder.Register(r =>
            {
                var config = r.Resolve<UnionizedConfiguration>();
                var optionsBuilder = new DbContextOptionsBuilder<UnionizedContext>();
                optionsBuilder.UseMySql(config.ConnectionString);

                return new UnionizedContext(optionsBuilder.Options);
            }).As<IUnionizedContext>().SingleInstance();

            builder.RegisterType<NetworkLogRepository>().As<INetworkLogRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TokenRepository>().As<ITokenRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MonitoredServersRepository>().As<IMonitorServersRepository>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
