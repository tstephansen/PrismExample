using System.Windows;

namespace PrismUnity
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bs = new Bootstrapper();
            bs.Run();
        }
    }
}
