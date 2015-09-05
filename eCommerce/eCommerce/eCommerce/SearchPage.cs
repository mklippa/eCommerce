using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace eCommerce
{
    public class SearchPage : ContentPage
    {
        public SearchPage()
        {
            Padding = Device.OnPlatform(new Thickness(0, 20, 0, 0), new Thickness(0), new Thickness(0));
            Title = "Search";
            Content = new StackLayout
            {
                Children = {
					new Label { Text = "Search Page" }
				}
            };
        }
    }
}
