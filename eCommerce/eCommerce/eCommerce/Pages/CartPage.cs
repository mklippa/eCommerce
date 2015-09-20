using eCommerce.Viewes;
using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class CartPage : ContentPage
    {
        public CartPage()
        {
            Title = "Cart";

            var listView = new ListView();
            listView.ItemTapped += OnListViewItemTapped;
            listView.ItemsSource = new[] {"", "", ""};
            listView.ItemTemplate = new DataTemplate(typeof(CartCell));
            listView.RowHeight = 60;
            listView.Footer = new ContentView
            {
                Padding = new Thickness(10),
                Content = new Label
                {
                    BackgroundColor = Color.Green,
                    HorizontalOptions = LayoutOptions.End,
                    Text = "Total ammount: $10"
                }
            };

            Content = new StackLayout
            {
                Children =
                {
                    listView
                }
            };
        }

        private void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            
        }
    }
}
