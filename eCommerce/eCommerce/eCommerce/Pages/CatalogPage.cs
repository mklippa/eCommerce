using eCommerce.Client.Managers;
using eCommerce.Client.Objects;
using System.Collections.Generic;
using eCommerce.Enums;
using eCommerce.Viewes;
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

            if (_pageType == CatalogPageType.Product)
            {
                listView.RowHeight = 80;
                listView.ItemTemplate = new DataTemplate(typeof(ProductCell));
            }

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
                {
                    var selectedCategory = (Category) listView.SelectedItem;
                    await Navigation.PushAsync(new CatalogPage<Category>(CatalogPageType.Subcategory, selectedCategory.SubCategories));
                    listView.SelectedItem = null;
                    break;
                }
                case CatalogPageType.Subcategory:
                {
                    var selectedCategory = (Category) listView.SelectedItem;
                    var productManager = new ProductManager();
                    var products = productManager.GetProductsByCategoryId(selectedCategory.Id);
                    await Navigation.PushAsync(new CatalogPage<Product>(CatalogPageType.Product, products));
                    listView.SelectedItem = null;
                    break;
                }
                case CatalogPageType.Product:
                {
                    var selectedProduct = (Product) listView.SelectedItem;
                    await Navigation.PushAsync(new ProductPage(selectedProduct));
                    listView.SelectedItem = null;
                    break;
                }
            }
        }
    }
}
