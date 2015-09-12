using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class CartPage : ContentPage
    {
        public CartPage()
        {
            Padding = Device.OnPlatform(new Thickness(0, 20, 0, 0), new Thickness(0), new Thickness(0));
            Title = "Cart";
            Icon = "cart.png";
            Content = new StackLayout
            {
                Children = {
					new Label { Text = "Cart Page" }
				}
            };
        }
    }
}
