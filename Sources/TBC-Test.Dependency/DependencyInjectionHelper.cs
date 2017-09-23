using SimpleInjector;
using SimpleInjector.Extensions.LifetimeScoping;
using TBC_Test.Configuration;
using TBC_Test.DAL.Abstract;
using TBC_Test.DAL.EF;

namespace TBC_Test.Dependency
{
    public static class DependencyInjectionHelper
    {
        private static Container _container;
        private static bool _isConfigured;

        private static readonly Lifestyle _LIFESTYLE = Lifestyle.Scoped;

        public static void Configure()
        {
            if (_isConfigured)
            {
                return;
            }

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle();
            container.Options.AllowOverridingRegistrations = true;
            Configure(container);
        }

        public static void Configure(Container container)
        {
            if (_isConfigured)
            {
                return;
            }

            _container = container;

            _container.Register(
                () => new TbcDbContext(ApplicationSettings.Instance.DbSetting.ApplicationConnectionString),
                _LIFESTYLE);

            _container.Register<IPersonsRepository, PersonsRepository>();

            _isConfigured = true;
        }

        /// <exception cref="DependencyInjectionException" accessor="get">Only in case when the no one of the 
        /// methods Configure was called.</exception>
        public static Container GetContainer()
        {
            if (!_isConfigured)
            {
                throw new DependencyInjectionException(
                    $"No one of methods {nameof(DependencyInjectionHelper)}.{nameof(DependencyInjectionHelper.Configure)} was called");
            }

            return _container;
        }

        public static T Resolve<T>() where T : class
        {
            if (!_isConfigured)
            {
                Configure();
            }

            return _container.GetInstance<T>();
        }

        private static void Register<TImplementation>()
            where TImplementation : class
        {
            _container.Register<TImplementation>(_LIFESTYLE);
        }

        private static void Register<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            _container.Register<TService, TImplementation>(_LIFESTYLE);
        }
    }
}