using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace eCommerce
{
    public class InfoPage : ContentPage
    {
        public InfoPage()
        {
            Title = "Info";
            Content = new StackLayout
            {
                Children = {
					new Label { Text = "Info Page" }
				}
            };
        }
    }
}
