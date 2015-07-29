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

        /// <summary>
        /// Unity Constructor
        /// </summary>
        /// <param name="viewModel"></param>
        public ViewOne([Dependency("ViewOneViewModel")]IViewModel viewModel)
        {
            InitializeComponent();
            UnityViewModel = viewModel;
        }

        public IViewModel UnityViewModel
        {
            get { return (IViewModel) DataContext; }
            set { DataContext = value; }
        }
        
        public string Header
        {
            get
            {
                if (ViewModel != null)
                {
                    return ViewModel.Header;
                }
                else
                {
                    return UnityViewModel.Header;
                }
            }
            set
            {
                if (ViewModel != null)
                {
                    ViewModel.Header = value;
                }
                else
                {
                    UnityViewModel.Header = value;
                }
            }
        }
    }
}
