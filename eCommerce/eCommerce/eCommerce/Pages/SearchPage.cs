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
        private readonly CategoryManager _categoryManager;
        private readonly ObservableCollection<Category> _categoriesList;
        private readonly CatalogPageType _pageType;
        private readonly Category _parentCategory;
        private IEnumerable<Category> _categories;

        public SearchPage(CatalogPageType pageType, Category parentCategory = null)
        {
            _parentCategory = parentCategory;
            _pageType = pageType;
            _categoryManager = new CategoryManager();
            _categoriesList = new ObservableCollection<Category>();

            var searchBar = new SearchBar();
            searchBar.TextChanged += OnSearchBarTextChanged;

            var listView = new ListView();
            listView.ItemTapped += OnListViewItemTapped;
            listView.ItemsSource = _categoriesList;

            Title = _pageType.ToString();

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

            var parentCategory = (Category) listView.SelectedItem;

            await Navigation.PushAsync(new SearchPage(_pageType, parentCategory));
            listView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _categories = _parentCategory == null
                ? _categoryManager.GetAll()
                : _parentCategory.SubCategories;

            _categoriesList.FillWith(_categories);
        }

        private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            var text = ((SearchBar) sender).Text;

            var categories = string.IsNullOrEmpty(text)
                ? _categories 
                : _categories.Where(c => c.Name.ToLower().Contains(text.ToLower()));

            _categoriesList.FillWith(categories);
        }
    }
}
