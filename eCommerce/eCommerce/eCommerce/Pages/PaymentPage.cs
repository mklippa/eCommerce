using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class PaymentPage : ContentPage
    {
        public PaymentPage()
        {
            Content = new StackLayout
            {
                Children = {
					new Label { Text = "Hello ContentPage" }
				}
            };
        }
    }
}
