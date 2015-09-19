using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class CartNavigationPage : NavigationPage
    {
        public CartNavigationPage()
        {
            Title = "Cart";
            Icon = "cart.png";

            PushAsync(new CartPage());
        }
    }
}
