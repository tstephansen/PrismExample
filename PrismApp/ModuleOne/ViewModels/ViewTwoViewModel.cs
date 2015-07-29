using System;
using System.ComponentModel.Composition;
using Infrastructure.Core;
using Infrastructure.Interfaces;
using Microsoft.Practices.Prism.Regions;

namespace ModuleOne.ViewModels
{
    [Export(typeof(ViewTwoViewModel))]
    public class ViewTwoViewModel : ViewModelBase, IViewModel, INavigationAware
    {
        #region Constructors
        [ImportingConstructor]
        public ViewTwoViewModel(INavMethods navMethods)
        {
            Title = "ViewTwoViewModel";
            Header = "View Two";
            if (navMethods == null) throw new ArgumentNullException("navMethods");
            _navMethods = navMethods;
            NavigateToViewOneCommand = new RelayCommand(NavigateToViewOne);
            NavigateToViewOneAndCloseCommand = new RelayCommand(NavigateToViewOneAndClose);
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
        public IRelayCommand NavigateToViewOneAndCloseCommand { get; set; }
        public IRelayCommand NavigateToViewOneCommand { get; set; }
        public IRelayCommand NavigateToViewThreeAndCloseCommand { get; set; }
        public IRelayCommand NavigateToViewThreeCommand { get; set; }
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

        private void NavigateToViewThree()
        {
            if (!string.IsNullOrWhiteSpace(ParameterExample))
            {
                _navMethods.NavigateWith(new NavModel("ViewThree",
                    new NavigationParameters {{"Example", ParameterExample}}));
            }
            else
            {
                _navMethods.Navigate(new NavModel("ViewThree"));
            }   
        }

        private void NavigateToViewThreeAndClose()
        {
            if (!string.IsNullOrWhiteSpace(ParameterExample))
            {
                _navMethods.NavigateWithClose(new NavModel("ViewThree",
                    new NavigationParameters { { "Example", ParameterExample } }));
            }
            else
            {
                _navMethods.NavigateClose(new NavModel("ViewThree"));
            }
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
                if(_parameterExample == value) return;
                _parameterExample = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
