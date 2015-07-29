using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Windows;
using Dragablz;
using Infrastructure.Interfaces;
using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using PrismMEF.Views;

namespace PrismMEF
{
    public class Bootstrapper : MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            var shell = Container.GetExportedValue<Shell>("Shell");
            return shell;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            var modulePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules");
            var dirCatalog = new DirectoryCatalog(modulePath, "*.dll");
            var asyCatalog = new AssemblyCatalog(typeof(Bootstrapper).Assembly);
            var catalog = new AggregateCatalog(asyCatalog, dirCatalog);
            AggregateCatalog.Catalogs.Add(catalog);
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            PublicContainer = Container;
            PublicContainer.ComposeParts(this);
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            var regionBehaviorFactory = Container.GetExportedValue<IRegionBehaviorFactory>();
            Container.GetExportedValue<IRegionManager>();
            mappings.RegisterMapping(typeof(TabablzControl), new TabablzControlRegionAdapter(regionBehaviorFactory));
            return mappings;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var modulePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules");
            var catalog = new DirectoryModuleCatalog {ModulePath = modulePath};
            return catalog;
        }

        [Import(typeof(INavMethods))]
        public INavMethods NavigationMethods { get; set; }

        [Export(typeof(CompositionContainer))]
        public CompositionContainer PublicContainer { get; set; }
    }
}
