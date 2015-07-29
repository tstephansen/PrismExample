using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Dragablz;
using Infrastructure.Interfaces;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Infrastructure.Core
{
    public class NavMethods : INavMethods
    {
        public NavMethods(IUnityContainer container, IRegionManager regionManager)
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
            _container.Resolve<dynamic>(viewName);
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
            _container.Resolve<dynamic>(viewName);
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

        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;
        public TabablzControl ShellTabControl { get; set; }

    }
}
