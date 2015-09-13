using eCommerce.Client.Managers;
using eCommerce.Client.Objects;
using eCommerce.Enums;
using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class CatalogNavigationPage : NavigationPage
    {
        public CatalogNavigationPage()
        {
            var categoryManager = new CategoryManager();

            Title = "Catalog";
            Icon = "catalog.png";

            var categories = categoryManager.GetAll();

            PushAsync(new CatalogPage<Category>(CatalogPageType.Category,  categories));
        }
    }
}
