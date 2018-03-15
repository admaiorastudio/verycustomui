using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VeryCustomUI.Common;
using Xamarin.Forms;

namespace VeryCustomUI
{
	public partial class MainPage : ContentPage
	{
        class MainPageViewModel : PageViewModel
        {
            private ICommand _goToCommand;

            public ICommand GoToCommand
            {
                get
                {
                    if(_goToCommand == null)
                    {
                        _goToCommand = new Command(
                            async () =>
                            {
                                var p = new SecondaryPage();
                                await this.Navigation.PushAsync(p);
                            });
                    }

                    return _goToCommand;
                }
            }

            public MainPageViewModel(Page context)
                : base(context)
            {

            }
        }

        private MainPageViewModel _vm;

		public MainPage()
		{
			InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            this.HeaderBar.SetContext(this);
            this.HeaderBar.SetBackButtonVisibility(false);

            _vm = new MainPageViewModel(this);
            this.BindingContext = _vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();            
        }
    }
}
