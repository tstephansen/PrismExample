using System.ComponentModel.Composition;
using Infrastructure.Interfaces;
using Microsoft.Practices.Unity;
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

        /// <summary>
        /// Unity Constructor
        /// </summary>
        /// <param name="viewModel"></param>
        public ViewThree([Dependency("ViewThreeViewModel")]IViewModel viewModel)
        {
            InitializeComponent();
            UnityViewModel = viewModel;
        }

        public IViewModel UnityViewModel
        {
            get { return (IViewModel)DataContext; }
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

        //public string Header
        //{
        //    get { return ViewModel.Header; }
        //    set { ViewModel.Header = value; }
        //}
    }
}
