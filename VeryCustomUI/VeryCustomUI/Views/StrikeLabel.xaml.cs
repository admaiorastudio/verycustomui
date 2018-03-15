using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VeryCustomUI.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StrikeLabel : ContentView
	{
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(StrikeLabel));

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public StrikeLabel()
		{
			InitializeComponent();

            //this.BindingContext = this;
		}
	}
}