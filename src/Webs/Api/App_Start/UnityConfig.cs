using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using TimeTracker.Api.Modules;

namespace Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            //Autofac Configuration
            var builder = new ContainerBuilder();
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EfModule());
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}