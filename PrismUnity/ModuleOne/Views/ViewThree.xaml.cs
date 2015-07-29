using Infrastructure.Interfaces;
using Microsoft.Practices.Unity;

namespace ModuleOne.Views
{
    /// <summary>
    /// Interaction logic for ViewThree.xaml
    /// </summary>
    public partial class ViewThree : IView
    {
        /// <summary>
        /// Unity Constructor
        /// </summary>
        /// <param name="viewModel"></param>
        public ViewThree([Dependency("ViewThreeViewModel")]IViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

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
