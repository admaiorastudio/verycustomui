using System.Reflection;
using VeryCustomUI.Common;
using Xamarin.Forms;

namespace VeryCustomUI.Controls
{
    public class FontAwesomeLabel : Label
    {
        //Constructor for XAML use
        public FontAwesomeLabel()
        {            
            switch(Device.RuntimePlatform)
            {
                case Device.iOS:
                    this.FontFamily = FontAwesome.Typeface;
                    break;
                case Device.Android:
                    this.FontFamily = $"{FontAwesome.Typeface}.ttf#{FontAwesome.Typeface}";
                    break;
                case Device.WinPhone:
                    this.FontFamily = $"/Assets/Fonts/{FontAwesome.Typeface}.ttf#{FontAwesome.Typeface}";
                    break;
            }            
        }
    }
}