using System.ComponentModel.Composition;
using Infrastructure.Interfaces;
using Microsoft.Practices.Unity;
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

        //public string Header
        //{
        //    get { return ViewModel.Header; }
        //    set { ViewModel.Header = value; }
        //}

        /// <summary>
        /// Unity Constructor
        /// </summary>
        /// <param name="viewModel"></param>
        public ViewTwo([Dependency("ViewTwoViewModel")]IViewModel viewModel)
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
    }
}
