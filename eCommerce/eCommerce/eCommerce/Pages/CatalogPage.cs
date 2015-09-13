using eCommerce.Client.Objects;
using System.Collections.Generic;
using eCommerce.Enums;
using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class CatalogPage<T> : ContentPage where T : BaseObject
    {
        private readonly CatalogPageType _pageType;

        public CatalogPage(CatalogPageType pageType, IEnumerable<T> items)
        {
            _pageType = pageType;

            var listView = new ListView();
            listView.ItemTapped += OnListViewItemTapped;
            listView.ItemsSource = items;

            Title = pageType.ToString();
            Content = new StackLayout
            {
                Children =
                {
                    listView
                }
            };
        }

        private async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            var listView = (ListView)sender;
            if (listView.SelectedItem == null)
                return;

            switch (_pageType)
            {
                case CatalogPageType.Category:
                    var selectedCategory = (Category)listView.SelectedItem;
                    await Navigation.PushAsync(new CatalogPage<Category>(CatalogPageType.Subcategory, selectedCategory.SubCategories));
                    listView.SelectedItem = null;
                    break;
                case CatalogPageType.Subcategory:
                    break;
                case CatalogPageType.Product:
                    break;
            }
        }
    }
}
