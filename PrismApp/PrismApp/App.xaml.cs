using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PrismApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ///// <summary>
        ///// This is used for the MEF Bootstrapper.
        ///// </summary>
        ///// <param name="e"></param>
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);
        //    var bs = new BootstrapperMef();
        //    bs.Run();
        //}

        /// <summary>
        /// This is used for the Unity Bootstrapper
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bs = new BootstrapperUnity();
            bs.Run();
        }


    }
}
