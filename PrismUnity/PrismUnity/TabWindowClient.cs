using System.Windows;
using Dragablz;

namespace PrismUnity
{
    public class TabWindowClient : IInterTabClient
    {
        public INewTabHost<Window> GetNewHost(IInterTabClient interTabClient, object partition, TabablzControl source)
        {
            var view = new TabWindow();
            view.AllowsTransparency = true;
            view.WindowStyle = WindowStyle.None;
            return new NewTabHost<TabWindow>(view, view.InitialTabablzControl);
        }

        public TabEmptiedResponse TabEmptiedHandler(TabablzControl tabControl, Window window)
        {
            return TabEmptiedResponse.CloseWindowOrLayoutBranch;
        }
    }
}
