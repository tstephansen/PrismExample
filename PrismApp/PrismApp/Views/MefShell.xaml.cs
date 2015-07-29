using System;
using System.ComponentModel.Composition;
using System.Windows;
using Dragablz;
using Infrastructure.Interfaces;
using PrismApp.ViewModels;

namespace PrismApp.Views
{
    /// <summary>
    /// Interaction logic for MefShell.xaml
    /// </summary>
    [Export("MefShell")]
    public partial class MefShell
    {
        [ImportingConstructor]
        public MefShell(INavMethods navMethods)
        {
            InitializeComponent();
            if (navMethods == null) throw new ArgumentNullException("navMethods");
            navMethods.ShellTabControl = MainTabControl;
        }

        [Import]
        public MefShellViewModel ViewModel { set { this.DataContext = value; } }
    }
}
