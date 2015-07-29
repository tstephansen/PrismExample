using Dragablz;

namespace Infrastructure.Interfaces
{
    public interface INavMethods
    {
        TabablzControl ShellTabControl { get; set; }
        void Navigate(INavModel navModel);
        void NavigateWith(INavModel navModel);
        void NavigateClose(INavModel navModel);
        void NavigateWithClose(INavModel navModel);
        void CloseTab(dynamic viewModel);
    }
}
