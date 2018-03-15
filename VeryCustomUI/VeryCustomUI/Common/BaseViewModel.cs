using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VeryCustomUI.Common
{
    class BaseViewModel : INotifyPropertyChanged
    {
        #region Costants and Fields

        private bool _isBusy;

        private Dictionary<string, Action> _moments;

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructors

        public BaseViewModel()
        {
            _moments = new Dictionary<string, Action>();
        }

        #endregion

        #region Properties

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        protected INavigation Navigation
        {
            get
            {
                if (App.Current == null)
                    return null;

                var container = ((App)App.Current).Container;
                return container.Resolve<INavigation>();                
            }
        }

        #endregion

        #region Event Raising Methods

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName == null)
                return;

            if (propertyName == String.Empty)
                return;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Methods

        protected bool SetProperty<T>(ref T backingStore, T value,
            string chainedPropertyName = "",
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            OnPropertyChanged(chainedPropertyName);            
            return true;
        }

        #endregion
    }    

    class PageViewModel : BaseViewModel
    {
        #region Constants and Fields

        private Page _context;

        #endregion

        #region Consturctors

        public PageViewModel(Page context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        protected Task DisplayAlert(string title, string message, string cancel)
        {
            return _context.DisplayAlert(title, message, cancel);
        }

        protected Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return _context.DisplayAlert(title, message, accept, cancel);
        }

        #endregion
    }
}
