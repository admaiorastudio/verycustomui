using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VeryCustomUI.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VeryCustomUI.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HeaderBar : ContentView
	{
        class HeaderBarViewModel : BaseViewModel
        {
            private string _title;

            private bool _isBackVisible;
            private bool _isActionVisible;

            private string _actionIcon;

            private ICommand _backCommand;
            private ICommand _actionCommand;

            public string Title
            {
                get { return _title; }
                set { SetProperty(ref _title, value); }
            }

            public bool IsBackVisible
            {
                get { return _isBackVisible; }
                set { SetProperty(ref _isBackVisible, value); }
            }

            public bool IsActionVisible
            {
                get { return _isActionVisible; }
                set { SetProperty(ref _isActionVisible, value); }
            }

            public INavigation Navigation
            {
                get;
                set;
            }

            public string ActionIcon
            {
                get { return _actionIcon; }
                set { SetProperty(ref _actionIcon, value); }
            }

            public Action Action
            {
                get;
                set;
            }

            public ICommand BackCommand
            {
                get
                {
                    if(_backCommand == null)
                    {
                        _backCommand = new Command(
                            async () =>
                            {
                                await this.Navigation?.PopAsync();
                            });
                    }

                    return _backCommand;
                }
            }

            public ICommand ActionCommand
            {
                get
                {
                    if (_actionCommand == null)
                    {
                        _actionCommand = new Command(
                            () =>
                            {
                                this.Action?.Invoke();
                            });
                    }

                    return _actionCommand;
                }
            }

            public HeaderBarViewModel()
            {                
            }
        }

        private HeaderBarViewModel _vm;        

        public HeaderBar()
		{
			InitializeComponent();

            _vm = new HeaderBarViewModel();
            this.BindingContext = _vm;
        }

        public void SetContext(Page context)
        {
            SetTitle(context.Title);

            if (context.Navigation != null)
            {
                _vm.Navigation = context.Navigation;
                bool isVisible = context.Navigation.NavigationStack.Count > 1;
                SetBackButtonVisibility(isVisible);
            }
        }

        public void SetTitle(string tile)
        {
            if (_vm != null)
                _vm.Title = tile;
        }

        public void SetBackButtonVisibility(bool isVisible)
        {
            if(_vm != null)
                _vm.IsBackVisible = isVisible;
        }

        public void SetActionButtonVisiblity(bool isVisible)
        {
            if (_vm != null)
                _vm.IsActionVisible = isVisible;
        }

        public void SetAction(string icon, Action action)
        {
            if (_vm != null)
            {
                _vm.ActionIcon = icon ?? FontAwesome.FAInfo;
                _vm.IsActionVisible = true;
                _vm.Action = action;
            }
        }
    }
}