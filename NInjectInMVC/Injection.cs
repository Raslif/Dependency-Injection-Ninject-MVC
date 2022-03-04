using Ninject.Modules;
using NInjectInMVC.Models;
using NInjectInMVC.Models.Abstract;
using NInjectInMVC.Models.Entity;

namespace NInjectInMVC
{
    public class Injection : NinjectModule
    {
        public override void Load()
        {
            Bind<IEmployee>().To<Employee>();

            /* Will consider only the constructor with most number of parameters */
            Bind<IConnection>().To<Connection>()
                .WithConstructorArgument("connectionString", "This is my connection string")
                .WithConstructorArgument("test", "test123")
                .WithConstructorArgument("data", "data123")
                .WithConstructorArgument("connectionDTO",
                                         new ConnectionDTO { ConnectionString = "This is my connection string from Property" });

            Bind<IData>().To<FileData>().Named("FileData");
            Bind<IData>().To<DbData>().Named("DbData");
            Bind<ICustomer>().To<Customer>().Named("customer");
        }
    }
}