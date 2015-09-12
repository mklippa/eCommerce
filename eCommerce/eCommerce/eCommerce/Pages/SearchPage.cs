using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using eCommerce.Core.Models;
using eCommerce.Core.Repositories;
using eCommerce.Enums;
using eCommerce.Extensions;
using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class SearchPage : ContentPage
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly ObservableCollection<Category> _categoriesList;
        private readonly SearchPageType _pageType;
        private readonly Category _parentCategory;
        private IEnumerable<Category> _categories;

        public SearchPage(SearchPageType pageType, Category parentCategory = null)
        {
            _parentCategory = parentCategory;
            _pageType = pageType;
            _categoryRepository = new CategoryRepository();
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
                ? _categoryRepository.GetAll()
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
