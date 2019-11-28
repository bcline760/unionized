using System;

using Autofac;
using Autofac.Core;

using Unionized.Model.Database;
using Unionized.Model.OpenHab;
using Unionized.Service;

namespace Unionized.Service
{
    public static class RegisterModules
    {
        public static void Register(ContainerBuilder builder, UnionizedConfiguration config)
        {
            builder.RegisterModule(new CoreModule());

            var dbModule = new DatabaseModule
            {
                MongoDatabase = config.DatabaseName,
                MongoServer = config.DatabaseServer,
                MongoPort = config.DatabasePort
            };

            builder.RegisterModule(dbModule);
            builder.RegisterModule(new ServiceModule());
        }
    }
}
