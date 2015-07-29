using System;
using System.ComponentModel.Composition;
using Infrastructure.Interfaces;
using PrismMEF.ViewModels;

namespace PrismMEF.Views
{
    /// <summary>
    /// Interaction logic for MefShell.xaml
    /// </summary>
    [Export("Shell")]
    public partial class Shell
    {
        [ImportingConstructor]
        public Shell(INavMethods navMethods)
        {
            InitializeComponent();
            if (navMethods == null) throw new ArgumentNullException("navMethods");
            navMethods.ShellTabControl = MainTabControl;
        }

        [Import]
        public ShellViewModel ViewModel { set { this.DataContext = value; } }
    }
}
