using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class InfoPage : ContentPage
    {
        public InfoPage()
        {
            Padding = Device.OnPlatform(new Thickness(0, 20, 0, 0), new Thickness(0), new Thickness(0));
            Title = "Info";
            Icon = "info.png";
            Content = new StackLayout
            {
                Children = {
					new Label { Text = "Info Page" }
				}
            };
        }
    }
}
