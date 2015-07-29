using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Runtime.CompilerServices;

namespace Infrastructure.Core
{
    /// <summary>
    /// Base class that I use for all of my view models.
    /// </summary>
    [Export(typeof(ViewModelBase))]
    public class ViewModelBase : INotifyPropertyChanged
    {

        #region VisualState
        /// <summary>
        /// The view model visual state
        /// </summary>
        private string _viewModelVisualState = string.Empty;
        /// <summary>
        /// Gets or sets the visual state of the view.
        /// </summary>
        /// <value>The state of the view.</value>
        public virtual string ViewModelVisualState
        {
            get { return _viewModelVisualState; }
            set
            {
                _viewModelVisualState = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
