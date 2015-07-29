using System.Windows;

namespace PrismMEF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// This is used for the MEF Bootstrapper.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bs = new Bootstrapper();
            bs.Run();
        }
    }
}
