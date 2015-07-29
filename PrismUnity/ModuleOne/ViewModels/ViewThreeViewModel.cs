using System;
using System.ComponentModel.Composition;
using Infrastructure.Core;
using Infrastructure.Interfaces;
using Microsoft.Practices.Prism.Regions;

namespace ModuleOne.ViewModels
{
    public class ViewThreeViewModel : ViewModelBase, IViewModel, INavigationAware
    {
        #region Constructors
        public ViewThreeViewModel(INavMethods navMethods)
        {
            Title = "ViewThreeViewModel";
            Header = "View Three";
            if (navMethods == null) throw new ArgumentNullException("navMethods");
            _navMethods = navMethods;
            NavigateToViewOneCommand = new RelayCommand(NavigateToViewOne);
            NavigateToViewOneAndCloseCommand = new RelayCommand(NavigateToViewOneAndClose);
            NavigateToViewTwoCommand = new RelayCommand(NavigateToViewTwo);
            NavigateToViewTwoAndCloseCommand = new RelayCommand(NavigateToViewTwoAndClose);
        }
        #endregion

        #region INavigationAware
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext == null) throw new ArgumentNullException("navigationContext");
            ParameterExample = navigationContext.Parameters["Example"] as string;
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
        public IRelayCommand NavigateToViewOneAndCloseCommand { get; set; }
        public IRelayCommand NavigateToViewOneCommand { get; set; }
        public IRelayCommand NavigateToViewTwoAndCloseCommand { get; set; }
        public IRelayCommand NavigateToViewTwoCommand { get; set; }
        #endregion

        #region Methods
        private void NavigateToViewOne()
        {
            _navMethods.Navigate(new NavModel("ViewOne"));
        }

        private void NavigateToViewOneAndClose()
        {
            _navMethods.NavigateClose(new NavModel("ViewOne", this));
        }

        private void NavigateToViewTwo()
        {
            _navMethods.Navigate(new NavModel("ViewTwo"));
        }

        private void NavigateToViewTwoAndClose()
        {
            _navMethods.NavigateClose(new NavModel("ViewTwo", this));
        }
        #endregion

        #region Properties
        private readonly INavMethods _navMethods;
        public string Title { get; set; }
        public string Header { get; set; }

        private string _parameterExample;
        public string ParameterExample
        {
            get { return _parameterExample; }
            set
            {
                if (_parameterExample == value) return;
                _parameterExample = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
