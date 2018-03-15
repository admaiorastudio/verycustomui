using System.Reflection;
using VeryCustomUI.Common;
using Xamarin.Forms;

namespace VeryCustomUI.Controls
{
    public class FontAwesomeButton : Button
    {
        //Must match the exact "Name" of the font which you can get by double clicking the TTF in Windows
        public const string Typeface = "FontAwesome";

        //Constructor for XAML use
        public FontAwesomeButton()
        {            
            switch(Device.RuntimePlatform)
            {
                case Device.iOS:
                    this.FontFamily = FontAwesome.Typeface;
                    break;
                case Device.Android:
                    this.FontFamily = $"{FontAwesome.Typeface}.ttf#{FontAwesome.Typeface}";
                    break;
            }
        }        
    }
}