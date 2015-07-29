using System;
using Infrastructure.Core;
using Infrastructure.Interfaces;
using Microsoft.Practices.Prism.Regions;

namespace ModuleOne.ViewModels
{
    public class ViewOneViewModel : ViewModelBase, IViewModel, INavigationAware
    {
        #region Constructors
        public ViewOneViewModel(INavMethods navMethods)
        {
            Title = "ViewOneViewModel";
            Header = "View One";
            if(navMethods == null) throw new ArgumentNullException("navMethods");
            _navMethods = navMethods;
            NavigateToViewTwoCommand = new RelayCommand(NavigateToViewTwo);
            NavigateToViewTwoAndCloseCommand = new RelayCommand(NavigateToViewTwoAndClose);
            NavigateToViewThreeCommand = new RelayCommand(NavigateToViewThree);
            NavigateToViewThreeAndCloseCommand = new RelayCommand(NavigateToViewThreeAndClose);
        }
        #endregion

        #region INavigationAware
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // Not Implemented in this example.
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
            // If you want to create multiple versions of this view then you need to set the 
            // PartCreationPolicy to NonShared and write code to determine if the view is 
            // a navigation target or not.
        }
        
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // Not Implemented in this example.
        }
        #endregion

        #region Commands
        public IRelayCommand NavigateToViewTwoAndCloseCommand { get; set; }
        public IRelayCommand NavigateToViewTwoCommand { get; set; }
        public IRelayCommand NavigateToViewThreeAndCloseCommand { get; set; }
        public IRelayCommand NavigateToViewThreeCommand { get; set; }
        #endregion

        #region Methods
        private void NavigateToViewTwo()
        {
            _navMethods.Navigate(new NavModel("ViewTwo"));
        }

        private void NavigateToViewTwoAndClose()
        {
            _navMethods.NavigateClose(new NavModel("ViewTwo", this));
        }

        private void NavigateToViewThree()
        {
            _navMethods.Navigate(new NavModel("ViewThree"));
        }

        private void NavigateToViewThreeAndClose()
        {
            _navMethods.NavigateClose(new NavModel("ViewThree", this));
        }
        #endregion

        #region Properties
        private readonly INavMethods _navMethods;
        public string Title { get; set; }
        public string Header { get; set; }
        #endregion
    }
}
