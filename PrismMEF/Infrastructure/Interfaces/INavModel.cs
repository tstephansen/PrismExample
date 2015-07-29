using Microsoft.Practices.Prism.Regions;

namespace Infrastructure.Interfaces
{
    public interface INavModel
    {
        string ViewName { get; set; }
        NavigationParameters NavigationParameters { get; set; }
        dynamic ViewModel { get; set; }
    }
}
