using System.Web.Http;
using Serilog;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using Tbc.Common;
using TBC_Test.Dependency;
using TBC_Test.Web.API;
using WebActivator;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorWebApiInitializer), "Initialize")]

namespace TBC_Test.Web.API
{
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            Utils.WrapWithLogAction(s => Log.Logger.Information(s), () =>
            {
                var container = new Container();
                container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

                InitializeContainer(container);

                container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

                container.Verify();

                GlobalConfiguration.Configuration.DependencyResolver =
                    new SimpleInjectorWebApiDependencyResolver(container);
            }, $"{nameof(SimpleInjectorWebApiInitializer)}.{nameof(Initialize)}");
        }

        private static void InitializeContainer(Container container)
        {
            DependencyInjectionHelper.Configure(container);
        }
    }
}