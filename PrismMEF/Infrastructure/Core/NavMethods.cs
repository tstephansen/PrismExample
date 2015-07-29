using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Dragablz;
using Infrastructure.Interfaces;
using Microsoft.Practices.Prism.Regions;

namespace Infrastructure.Core
{
    /// <summary>
    /// A little helper I made to reduce the amount of code required for navigation.
    /// This is probably not the best way to do things but in a small-mid sized project I believe
    /// this is ok.
    /// </summary>
    [Export(typeof(INavMethods))]
    public class NavMethods : INavMethods
    {
        /// <summary>
        /// Constructor for MEF
        /// </summary>
        /// <param name="container"></param>
        /// <param name="regionManager"></param>
        [ImportingConstructor]
        public NavMethods(CompositionContainer container, IRegionManager regionManager)
        {
            if (container == null) throw new ArgumentNullException("container");
            if (regionManager == null) throw new ArgumentNullException("regionManager");
            _container = container;
            _regionManager = regionManager;
        }

        public void Navigate(INavModel navModel)
        {
            var viewName = navModel.ViewName;
            if (string.IsNullOrWhiteSpace(viewName)) return;
            _container.GetExportedValue<dynamic>(viewName);
            try
            {
                _regionManager.RequestNavigate(RegionNames.MainContentRegion, new Uri(viewName, UriKind.Relative));
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void NavigateWith(INavModel navModel)
        {
            var viewName = navModel.ViewName;
            if (string.IsNullOrWhiteSpace(viewName)) return;
            _container.GetExportedValue<dynamic>(viewName);
            try
            {
                _regionManager.RequestNavigate(RegionNames.MainContentRegion, new Uri(viewName, UriKind.Relative), navModel.NavigationParameters);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void NavigateClose(INavModel navModel)
        {
            var viewName = navModel.ViewName;
            if (string.IsNullOrWhiteSpace(viewName)) return;
            CloseTab(navModel.ViewModel);
            Navigate(navModel);
        }

        public void NavigateWithClose(INavModel navModel)
        {
            CloseTab(navModel.ViewModel);
            NavigateWith(navModel);
        }

        private readonly CompositionContainer _container;
        private readonly IRegionManager _regionManager;
        public TabablzControl ShellTabControl { get; set; }

        /// <summary>
        /// Closes the current tab. If the tab implements IRegionMemberLifetime it will throw an exception (I haven't
        /// figured out a way around that yet) but you can catch it and remove the tab from the tab control (the view will 
        /// already have been removed from the region).
        /// </summary>
        /// <param name="viewModel"></param>
        public void CloseTab(dynamic viewModel)
        {
            var region = _regionManager.Regions[RegionNames.MainContentRegion];
            for (var i = 0; i < region.Views.Count(); i++)
            {
                var v = (UserControl)region.Views.ElementAt(i);
                var d = v.DataContext;
                if (d.GetType() != viewModel.GetType()) continue;
                try
                {
                    var fe = (FrameworkElement)v;
                    region.Remove(fe);
                }
                catch (Exception)
                {
                    for (var x = 0; x < ShellTabControl.Items.Count; x++)
                    {
                        var item = ShellTabControl.Items[x] as TabItem;
                        if (item == null) continue;
                        if (item.Content == v)
                        {
                            ShellTabControl.Items.RemoveAt(x);
                        }
                    }
                }
            }
        }
    }
}
