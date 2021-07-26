using System;
using Autofac;
using SpaceController.Contracts.Repositories;
using SpaceController.Contracts.Services;
using SpaceController.Repositories;
using SpaceController.Services;
using SpaceController.ViewModels;

namespace SpaceController.Bootstrap
{
    public static class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();


            builder.RegisterType<SightingsListViewModel>();
            builder.RegisterType<SightingDetailViewModel>();


            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<SightingsService>().As<ISightingsService>();
            builder.RegisterType<TxtRepository>().As<IGenericRepository>();

            _container = builder.Build();
        }

        public static object Resolve(Type typename)
        {
            return _container.Resolve(typename);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
