using System.ComponentModel.Composition;
using Infrastructure.Interfaces;
using Microsoft.Practices.Unity;
using ModuleOne.ViewModels;

namespace ModuleOne.Views
{
    /// <summary>
    /// Interaction logic for ViewOne.xaml
    /// </summary>
    [Export("ViewOne")]
    public partial class ViewOne : IView
    {
        /// <summary>
        /// MEF Constructor
        /// </summary>
        public ViewOne()
        {
            InitializeComponent();
        }

        [Import]
        public ViewOneViewModel ViewModel
        {
            get { return (ViewOneViewModel) DataContext; }
            set { DataContext = value; }
        }

        public string Header
        {
            get { return ViewModel.Header; }
            set { ViewModel.Header = value; }
        }
    }
}
