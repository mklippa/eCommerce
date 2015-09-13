using eCommerce.Client.Managers;
using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class SearchNavigationPage : NavigationPage
    {
        public SearchNavigationPage()
        {
            Title = "Search";
            Icon = "search.png";

            var productManager = new ProductManager();
            var products = productManager.GetAll();

            PushAsync(new SearchPage(products));
        }
    }
}
