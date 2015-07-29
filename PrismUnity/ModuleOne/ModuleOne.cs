using System;
using Infrastructure.Core;
using Infrastructure.Interfaces;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using ModuleOne.ViewModels;
using ModuleOne.Views;

namespace ModuleOne
{
    public class ModuleOne : IModule
    {
        public ModuleOne(IUnityContainer container, IRegionManager regionManager)
        {
            if(container == null)throw new ArgumentNullException("container");
            if(regionManager == null) throw new ArgumentNullException("regionManager");
            _container = container;
            _regionManager = regionManager;
            _navMethods = _container.Resolve<INavMethods>();
        }

        public void Initialize()
        {
            _container.RegisterType<Object, ViewOne>("ViewOne");
            _container.RegisterType<IViewModel, ViewOneViewModel>("ViewOneViewModel", new InjectionConstructor(_navMethods));
            _container.RegisterType<Object, ViewTwo>("ViewTwo");
            _container.RegisterType<IViewModel, ViewTwoViewModel>("ViewTwoViewModel", new InjectionConstructor(_navMethods));
            _container.RegisterType<Object, ViewThree>("ViewThree");
            _container.RegisterType<IViewModel, ViewThreeViewModel>("ViewThreeViewModel", new InjectionConstructor(_navMethods));
            var view = _container.Resolve<ViewOne>();
            var region = _regionManager.Regions[RegionNames.MainContentRegion];
            region.Add(view);
            _regionManager.RequestNavigate(RegionNames.MainContentRegion, new Uri("ViewOne", UriKind.Relative));
        }

        private readonly INavMethods _navMethods;
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;
    }
}
