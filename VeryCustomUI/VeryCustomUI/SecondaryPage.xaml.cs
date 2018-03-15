using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeryCustomUI.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VeryCustomUI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SecondaryPage : ContentPage
	{
		public SecondaryPage()
		{
			InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);       
            this.HeaderBar.SetContext(this);
            this.HeaderBar.SetBackButtonVisibility(true);
            this.HeaderBar.SetAction(FontAwesome.FAShoppingCart,
                async () =>
                {
                    await DisplayAlert(this.Title, "This your custom action!", "Ok");
                });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();            
        }
    }
}