using System;

using Autofac;
using Unionized.Model.API;
using Unionized.Model.Database;

namespace Unionized.Service
{
    public static class RegisterModules
    {
        public static void Register(ContainerBuilder builder, UnionizedConfiguration config)
        {
            builder.RegisterModule(new CoreModule());
            builder.RegisterModule(new DatabaseModule());
            builder.RegisterModule(new ApiModule());
            builder.RegisterModule(new ServiceModule());
        }
    }
}
