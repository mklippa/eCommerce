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
					new Label { Text = "Info Page" },
                    new Image
                    {
                        Source = ImageSource.FromResource("eCommerce.Images.Products.skates.jpg"),
                        WidthRequest = 70,
                        HeightRequest = 70
                    }
				}
            };
        }
    }
}
