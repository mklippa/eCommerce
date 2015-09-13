using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using eCommerce.Client.Managers;
using eCommerce.Client.Objects;
using eCommerce.Enums;
using eCommerce.Extensions;
using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class SearchPage : ContentPage
    {
        private readonly ObservableCollection<Product> _productsList;
        private readonly IEnumerable<Product> _products;

        public SearchPage(IEnumerable<Product> products)
        {
            _products = products;
            _productsList = new ObservableCollection<Product>(_products);

            var searchBar = new SearchBar();
            searchBar.TextChanged += OnSearchBarTextChanged;

            var listView = new ListView();
            listView.ItemTapped += OnListViewItemTapped;
            listView.ItemsSource = _productsList;

            Title = "Product";

            Content = new StackLayout
            {
                Children =
                {
                    searchBar,
                    listView
                }
            };
        }

        private async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            var listView = (ListView) sender;
            if (listView.SelectedItem == null)
                return;

            var selectedProduct = (Product) listView.SelectedItem;
            await Navigation.PushAsync(new ProductPage(selectedProduct));
            listView.SelectedItem = null;
        }

        private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            var text = ((SearchBar) sender).Text;

            var filteredProducts = string.IsNullOrEmpty(text)
                ? _products 
                : _products.Where(c => c.Name.ToLower().Contains(text.ToLower()));

            _productsList.FillWith(filteredProducts);
        }
    }
}
