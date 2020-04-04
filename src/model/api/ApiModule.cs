using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Unionized.Contract.Repository;
using Unionized.Model.API.Weather;

namespace Unionized.Model.API
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WeatherRepository>()
                .As<IWeatherRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
