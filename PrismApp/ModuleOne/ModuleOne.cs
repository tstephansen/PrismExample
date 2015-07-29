using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Infrastructure.Core;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using ModuleOne.Views;

namespace ModuleOne
{
    [ModuleExport(typeof(ModuleOne))]
    public class ModuleOne : IModule
    {
        [ImportingConstructor]
        public ModuleOne(IRegionManager regionManager, CompositionContainer container)
        {
            if(regionManager == null) throw new ArgumentNullException("regionManager");
            if(container == null) throw new ArgumentNullException("container");
            _regionManager = regionManager;
            _container = container;
        }

        private readonly IRegionManager _regionManager;
        private readonly CompositionContainer _container;
        

        /// <summary>
        /// Initialize ModuleOne and navigate to ViewOne.
        /// </summary>
        public void Initialize()
        {
            var region = _regionManager.Regions[RegionNames.MainContentRegion];
            var view = _container.GetExportedValue<ViewOne>("ViewOne");
            region.Add(view);
            try
            {
                _regionManager.RequestNavigate(RegionNames.MainContentRegion, new Uri("ViewOne", UriKind.Relative));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
