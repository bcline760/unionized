using Autofac;

using Unionized.Contract.Repository;
using Unionized.Model.API.HomeAssistant;

namespace Unionized.Model.API
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.Register(r =>
            //{
            //    var config = r.Resolve<UnionizedConfiguration>();
            //    var optionsBuilder = new DbContextOptionsBuilder<UnionizedContext>();
            //    optionsBuilder.UseMySql(config.ConnectionString);

            //    return new UnionizedContext(optionsBuilder.Options);
            //}).As<IUnionizedContext>().InstancePerLifetimeScope();

            UnionizedConfiguration config = null;
            builder.Register(r =>
            {
                config = r.Resolve<UnionizedConfiguration>();

                var switchRepo = new HaRepository(config.HomeAssistant);

                return switchRepo;
            }).As<IHaRepository>().InstancePerLifetimeScope();
        }
    }
}
