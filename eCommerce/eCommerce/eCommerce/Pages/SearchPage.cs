using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class SearchPage : ContentPage
    {
        public SearchPage()
        {
            Padding = Device.OnPlatform(new Thickness(0, 20, 0, 0), new Thickness(0), new Thickness(0));
            Title = "Search";
            Icon = "search.png";
            Content = new StackLayout
            {
                Children = {
					new Label { Text = "Search Page" }
				}
            };
        }
    }
}
