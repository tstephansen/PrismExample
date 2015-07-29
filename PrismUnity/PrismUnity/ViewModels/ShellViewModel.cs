using System;
using Infrastructure.Core;
using Infrastructure.Interfaces;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace PrismUnity.ViewModels
{
    public class ShellViewModel : ViewModelBase, IViewModel
    {
        public ShellViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            if (regionManager == null) throw new ArgumentNullException("regionManager");
            if (container == null) throw new ArgumentNullException("container");
            _regionManager = regionManager;
            _container = container;
            Title = "ShellViewModel";
            Header = "Unity Example";
            TabClient = new TabWindowClient();
        }

        private TabWindowClient _tabClient;
        public TabWindowClient TabClient
        {
            get { return _tabClient; }
            set
            {
                if (_tabClient == value) return;
                _tabClient = value;
                OnPropertyChanged();
            }
        }


        public string Title { get; set; }
        public string Header { get; set; }

        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;
    }

}
