using System.ComponentModel.Composition;
using Infrastructure.Interfaces;
using ModuleOne.ViewModels;

namespace ModuleOne.Views
{
    /// <summary>
    /// Interaction logic for ViewThree.xaml
    /// </summary>
    [Export("ViewThree")]
    public partial class ViewThree : IView
    {
        public ViewThree()
        {
            InitializeComponent();
        }

        [Import]
        public ViewThreeViewModel ViewModel
        {
            get { return (ViewThreeViewModel)DataContext; }
            set { DataContext = value; }
        }

        public string Header
        {
            get { return ViewModel.Header; }
            set { ViewModel.Header = value; }
        }
    }
}
