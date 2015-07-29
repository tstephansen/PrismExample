using System.ComponentModel.Composition;
using Infrastructure.Core;
using Infrastructure.Interfaces;

namespace PrismMEF.ViewModels
{
    [Export]
    public class ShellViewModel : ViewModelBase, IViewModel
    {
        public ShellViewModel()
        {
            TabClient = new TabWindowClient();
            Title = "ShellViewModel";
            Header = "MEF Example";
        }

        private TabWindowClient _tabClient;
        public TabWindowClient TabClient
        {
            get { return _tabClient; }
            set
            {
                if (_tabClient == value) return;
                _tabClient = value;
                OnPropertyChanged();
            }
        }

        public string Header { get; set; }
        public string Title { get; set; }
    }
}
