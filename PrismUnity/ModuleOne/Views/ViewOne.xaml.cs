using System.ComponentModel.Composition;
using Infrastructure.Interfaces;
using Microsoft.Practices.Unity;
using ModuleOne.ViewModels;

namespace ModuleOne.Views
{
    /// <summary>
    /// Interaction logic for ViewOne.xaml
    /// </summary>
    public partial class ViewOne : IView
    {
        /// <summary>
        /// Unity Constructor
        /// </summary>
        /// <param name="viewModel"></param>
        public ViewOne([Dependency("ViewOneViewModel")]IViewModel viewModel)
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
