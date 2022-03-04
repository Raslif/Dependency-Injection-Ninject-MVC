[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NInjectInMVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(NInjectInMVC.App_Start.NinjectWebCommon), "Stop")]
[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(NInjectInMVC.App_Start.NinjectWebCommon), "PostStart")]

namespace NInjectInMVC.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Web;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        // Invoke before the Application_Start event
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        // Invoke after the Application_Start event
        public static void PostStart()
        {

        }

        private static IKernel CreateKernel()
        {
            var standardKernal = new StandardKernel();
            try
            {
                standardKernal.Load(new Injection());
                standardKernal.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                standardKernal.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                InjectionResolver.Kernel = standardKernal; 
                return standardKernal;
            }
            catch
            {
                standardKernal.Dispose();
                throw;
            }
        }
    }
}