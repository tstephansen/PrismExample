using Infrastructure.Interfaces;
using Microsoft.Practices.Unity;
using ModuleOne.ViewModels;

namespace ModuleOne.Views
{
    /// <summary>
    /// Interaction logic for ViewTwo.xaml
    /// </summary>
    public partial class ViewTwo : IView
    {
        /// <summary>
        /// Unity Constructor
        /// </summary>
        /// <param name="viewModel"></param>
        public ViewTwo([Dependency("ViewTwoViewModel")]IViewModel viewModel)
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
