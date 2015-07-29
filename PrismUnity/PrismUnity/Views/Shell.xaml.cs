using System.Windows;
using Infrastructure.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace PrismUnity.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell([Dependency("ShellViewModel")]IViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            _navMethods.ShellTabControl = MainTabControl;
        }

        private INavMethods _navMethods = ServiceLocator.Current.GetInstance<INavMethods>();

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }

        public string Header
        {
            get { return ViewModel.Header; }
            set { ViewModel.Header = value; }
        }
    }
}
