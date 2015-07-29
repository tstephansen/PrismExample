using System.Windows;
using Dragablz;
using Infrastructure.Core;
using Infrastructure.Interfaces;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using PrismApp.ViewModels;
using PrismApp.Views;

namespace PrismApp
{
    public class BootstrapperUnity : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            var view = Container.TryResolve<UnityShell>();
            return view;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            var regionManager = Container.Resolve<IRegionManager>();
            _navMethods = new NavMethodsUnity(Container, regionManager);
            Container.RegisterInstance<INavMethods>(_navMethods, new ContainerControlledLifetimeManager());
            Container.RegisterType<IViewModel, UnityShellViewModel>("UnityShellViewModel", new InjectionConstructor(regionManager, Container));
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            var regionBehaviorFactory = Container.Resolve<IRegionBehaviorFactory>();
            mappings.RegisterMapping(typeof(TabablzControl), new TabablzControlRegionAdapter(regionBehaviorFactory));
            return mappings;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var version = AssemblyExtensions.ParseVersionNumber(typeof(BootstrapperUnity).Assembly).ToString();
            var moduleCatalog = new ModuleCatalog();
            moduleCatalog.AddModule
            (
                new ModuleInfo
                {
                    InitializationMode = InitializationMode.WhenAvailable,
                    Ref = "file://ModuleOne.dll",
                    ModuleName = "ModuleOne",
                    ModuleType = string.Format("ModuleOne.UnityModuleOne, ModuleOne, Version={0}, Culture=neutral, " +
                                                "PublicKeyToken=null", version)
                }
            );
            return moduleCatalog;
        }

        private INavMethods _navMethods;
    }
}
