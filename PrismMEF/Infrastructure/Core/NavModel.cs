using System.ComponentModel.Composition;
using Infrastructure.Interfaces;
using Microsoft.Practices.Prism.Regions;

namespace Infrastructure.Core
{
    /// <summary>
    /// This is a model used to pass navigation data.
    /// </summary>
    [Export(typeof(INavModel))]
    public class NavModel : INavModel
    {
        public NavModel(string viewName, NavigationParameters navParam = null, dynamic viewModel = null)
        {
            ViewName = viewName;
            if (navParam != null) NavigationParameters = navParam;
            if (viewModel != null) ViewModel = viewModel;
        }

        public NavModel(string viewName, dynamic viewModel)
        {
            ViewName = viewName;
            if (viewModel != null) ViewModel = viewModel;
        }

        public NavModel(string viewName, NavigationParameters navParam)
        {
            ViewName = viewName;
            if(navParam != null) NavigationParameters = navParam;
        }

        public dynamic ViewModel { get; set; }
        public string ViewName { get; set; }
        public NavigationParameters NavigationParameters { get; set; }
    }
}
