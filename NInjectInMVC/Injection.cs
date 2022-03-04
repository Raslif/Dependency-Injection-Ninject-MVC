using Ninject.Modules;
using NInjectInMVC.Models.Abstract;
using NInjectInMVC.Models.Entity;

namespace NInjectInMVC
{
    public class Injection : NinjectModule
    {
        public override void Load()
        {
            Bind<IEmployee>().To<Employee>();
        }
    }
}