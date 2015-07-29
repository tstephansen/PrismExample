using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Infrastructure.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace PrismApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UnityShell 
    {
        public UnityShell([Dependency("UnityShellViewModel")]IViewModel viewModel)
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
