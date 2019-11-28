using System;

using Autofac;
using AutoMapper;

using Unionized.Contract;
using Unionized.Contract.Repository;
//using Unionized.Model.Database.Repository;

namespace Unionized.Model.Database
{
    public class DatabaseModule : Module
    {
        public string MongoServer { get; set; }
        public int MongoPort { get; set; }

        public string MongoDatabase { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(r =>
            {
                var config = new MapperConfiguration(cfg =>
                  {
                      cfg.CreateMap<NetworkLog, NetworkLogModel>();
                      cfg.CreateMap<UserToken, UserTokenModel>().ReverseMap();
                  });

                var map = config.CreateMapper();

                return map;
            }).As<IMapper>().SingleInstance();

            //builder.RegisterType<NetworkLogRepository>().As<INetworkLogRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<TokenRepository>().As<ITokenRepository>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
