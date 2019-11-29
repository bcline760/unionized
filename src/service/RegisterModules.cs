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
            builder.RegisterModule(new DatabaseModule());
            builder.RegisterModule(new ServiceModule());
        }
    }
}
