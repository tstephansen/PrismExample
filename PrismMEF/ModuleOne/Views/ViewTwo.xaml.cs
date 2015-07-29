using System.ComponentModel.Composition;
using Infrastructure.Interfaces;
using ModuleOne.ViewModels;

namespace ModuleOne.Views
{
    /// <summary>
    /// Interaction logic for ViewTwo.xaml
    /// </summary>
    [Export("ViewTwo")]
    public partial class ViewTwo : IView
    {
        public ViewTwo()
        {
            InitializeComponent();
        }

        [Import]
        public ViewTwoViewModel ViewModel
        {
            get { return (ViewTwoViewModel)DataContext; }
            set { DataContext = value; }
        }

        public string Header
        {
            get { return ViewModel.Header; }
            set { ViewModel.Header = value; }
        }
    }
}
