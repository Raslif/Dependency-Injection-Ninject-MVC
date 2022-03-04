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
            Bind<IConnectionString>().To<ConnectionString>()
                .WithConstructorArgument("connectionString", "This is my connection string")
                .WithConstructorArgument("test", "test123")
                .WithConstructorArgument("data", "data123")
                .WithConstructorArgument("connectionDTO",
                                            new ConnectionDTO { ConnectionString = "This is my connection string from Property" });
        }
    }
}