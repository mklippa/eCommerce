using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class CatalogPage : ContentPage
    {
        public CatalogPage()
        {
            Padding = Device.OnPlatform(new Thickness(0, 20, 0, 0), new Thickness(0), new Thickness(0));
            Title = "Catalog";
            Icon = "Catalog.png";
            Content = new StackLayout
            {
                Children = {
					new Label { Text = "Catalog Page" }
				}
            };
        }
    }
}
