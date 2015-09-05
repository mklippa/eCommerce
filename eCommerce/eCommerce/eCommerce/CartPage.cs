using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace eCommerce
{
    public class CartPage : ContentPage
    {
        public CartPage()
        {
            Title = "Cart";
            Content = new StackLayout
            {
                Children = {
					new Label { Text = "Cart Page" }
				}
            };
        }
    }
}
