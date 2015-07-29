using System.ComponentModel.Composition;
using Infrastructure.Core;
using Infrastructure.Interfaces;

namespace PrismApp.ViewModels
{
    [Export]
    public class MefShellViewModel : ViewModelBase, IViewModel
    {
        public MefShellViewModel()
        {
            TabClient = new TabWindowClient();
            Title = "MefShellViewModel";
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
