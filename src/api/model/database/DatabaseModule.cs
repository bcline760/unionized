using System.Web;

using Autofac;
using AutoMapper;
using MongoDB.Driver;

using Unionized.Contract;
using Unionized.Interface.Repository;
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
                      cfg.CreateMap<MonitoredServer, MonitoredServersModel>().ReverseMap();
                  });

                var map = config.CreateMapper();

                return map;
            }).As<IMapper>().SingleInstance();

            builder.Register(r =>
            {
                var config = r.Resolve<UnionizedConfiguration>();
                var connectString = config.ConnectionString;

                var settings = MongoClientSettings.FromUrl(MongoUrl.Create(connectString));
                var client = new MongoClient(settings);
                IMongoDatabase db = client.GetDatabase(config.DatabaseName); //TODO: Not hardcode
                return db;
            }).As<IMongoDatabase>().SingleInstance();

            builder.RegisterType<NetworkLogRepository>().As<INetworkLogRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MonitoredServersRepository>().As<IMonitorServersRepository>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
