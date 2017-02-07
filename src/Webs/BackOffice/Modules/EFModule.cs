using System.Data.Entity;
using Autofac;
using RestMeet.Model;
using RestMeet.Repository;

namespace Api.Modules
{
    public class EFModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());

            builder.RegisterType(typeof (DataContext)).As(typeof (DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof (UnitOfWork)).As(typeof (IUnitOfWork)).InstancePerRequest();
        }
    }
}